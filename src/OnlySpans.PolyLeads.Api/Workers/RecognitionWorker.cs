using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using OnlySpans.PolyLeads.Api.Abstractions.Recognition;
using OnlySpans.PolyLeads.Api.Data.Contexts;
using OnlySpans.PolyLeads.Api.Data.Enums;
using OnlySpans.PolyLeads.Api.Data.Options;
using OnlySpans.PolyLeads.Api.Data.Records.Recognition;
using OnlySpans.PolyLeads.Api.Exceptions;

namespace OnlySpans.PolyLeads.Api.Workers;

public sealed class RecognitionWorkerRunner : IHostedService
{
    private static string JobId { get; } = "document-recognition";

    private IRecurringJobManager RecurringJobs { get; init; }
    private IOptions<RecognitionOptions> Options { get; init; }

    public RecognitionWorkerRunner(
        IRecurringJobManager recurringJobs,
        IOptions<RecognitionOptions> options)
    {
        RecurringJobs = recurringJobs;
        Options = options;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        RecurringJobs.AddOrUpdate<RecognitionWorker>(
            JobId,
            w => w.RecognizeDocumentsAsync(CancellationToken.None),
            Options.Value.Cron);

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) =>
        Task.CompletedTask;
}

public sealed class RecognitionWorker
{
    private ApplicationDbContext Context { get; init; }
    private Marten.IDocumentSession Session { get; init; }
    private ILogger<RecognitionWorker> Logger { get; init; }
    private IOptions<RecognitionOptions> Options { get; init; }
    private IHttpClientFactory HttpClientFactory { get; init; }
    private IDocumentRecognitionFactory RecognitionFactory { get; init; }

    public RecognitionWorker(
        ApplicationDbContext context,
        Marten.IDocumentSession session,
        ILogger<RecognitionWorker> logger,
        IOptions<RecognitionOptions> options,
        IHttpClientFactory httpClientFactory,
        IDocumentRecognitionFactory recognitionFactory)
    {
        Context = context;
        Session = session;
        Logger = logger;
        Options = options;
        HttpClientFactory = httpClientFactory;
        RecognitionFactory = recognitionFactory;
    }

    public async Task RecognizeDocumentsAsync(CancellationToken cancellationToken)
    {
        await using var transaction = await Context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            await RecognizeDocumentsAsyncInternal(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Возникла ошибка при работе Worker'а с распознованием");
            await transaction.RollbackAsync(cancellationToken);
        }
    }

    private async Task RecognizeDocumentsAsyncInternal(CancellationToken cancellationToken)
    {
        var queuedDocuments = await Context
           .Documents
           .Where(x => x.RecognitionStatus == RecognitionStatus.Queued)
           .Take(Options.Value.FilesBatchSize)
           .OrderBy(x => x.Id)
           .ToListAsync(cancellationToken);

        foreach (var document in queuedDocuments)
            document.RecognitionStatus = RecognitionStatus.Processing;

        await Context.SaveChangesAsync(cancellationToken);

        foreach (var document in queuedDocuments)
        {
            try
            {
                using var httpClient = HttpClientFactory.CreateClient();

                using var httpResponse = await httpClient
                   .GetAsync(document.DownloadUrl, cancellationToken);

                var contentType = httpResponse.Content.Headers.ContentType?.MediaType;

                RecognitionException.ThrowIfNull(
                    contentType,
                    $"Не удалось определить тип файла для документа с id {document.Id}");

                var recognizer = RecognitionFactory.Create(contentType);

                await using var fileContent = await httpResponse.Content.ReadAsStreamAsync(cancellationToken);

                var recognizedContent = await recognizer.RecognizeAsync(fileContent, cancellationToken);

                var recognitionResult = new Entities.RecognitionResult
                {
                    DocumentId = document.Id,
                    Content = PreprocessText(recognizedContent)
                };

                Session.Store(recognitionResult);
                await Session.SaveChangesAsync(cancellationToken);

                document.RecognitionStatus = RecognitionStatus.Success;
                await Context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Возникла ошибка при распознавании документа с id {Id}", document.Id);
                document.RecognitionStatus = RecognitionStatus.Error;
                await Context.SaveChangesAsync(cancellationToken);
            }
        }
    }

    private static string PreprocessText(RecognitionResult recognizedContent)
    {
        var joinedText = string.Join(' ', recognizedContent.Pages.Select(x => x.Text));
        return joinedText.Replace("\u0000", "");
    }
}
