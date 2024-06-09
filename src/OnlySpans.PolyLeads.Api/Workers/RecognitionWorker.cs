using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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
    private const string JobId = "document-recognition";

    private readonly IRecurringJobManager _recurringJobs;
    private readonly IOptions<RecognitionOptions> _options;

    public RecognitionWorkerRunner(
        IRecurringJobManager recurringJobs,
        IOptions<RecognitionOptions> options)
    {
        _recurringJobs = recurringJobs;
        _options = options;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _recurringJobs.AddOrUpdate<RecognitionWorker>(
            JobId,
            w => w.RecognizeDocumentsAsync(CancellationToken.None),
            _options.Value.Cron);

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) =>
        Task.CompletedTask;
}

public sealed class RecognitionWorker
{
    private readonly ApplicationDbContext _context;
    private readonly Marten.IDocumentSession _session;
    private readonly ILogger<RecognitionWorker> _logger;
    private readonly IOptions<RecognitionOptions> _options;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IDocumentRecognitionFactory _recognitionFactory;

    public RecognitionWorker(
        ApplicationDbContext context,
        Marten.IDocumentSession session,
        ILogger<RecognitionWorker> logger,
        IOptions<RecognitionOptions> options,
        IHttpClientFactory httpClientFactory,
        IDocumentRecognitionFactory recognitionFactory)
    {
        _context = context;
        _session = session;
        _logger = logger;
        _options = options;
        _httpClientFactory = httpClientFactory;
        _recognitionFactory = recognitionFactory;
    }

    public async Task RecognizeDocumentsAsync(CancellationToken cancellationToken)
    {
        IDbContextTransaction? transaction = null;

        try
        {
            transaction = await RecognizeDocumentsAsyncInternal(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Возникла ошибка при работе Worker'а с распознованием");

            if (transaction is not null)
                await transaction.RollbackAsync(cancellationToken);
        }
        finally
        {
            if (transaction is not null)
                await transaction.DisposeAsync();
        }

    }

    private async Task<IDbContextTransaction> RecognizeDocumentsAsyncInternal(
        CancellationToken cancellationToken)
    {
        var queuedDocuments = await _context
           .Documents
           .Where(x => x.RecognitionStatus == RecognitionStatus.Queued)
           .Take(_options.Value.FilesBatchSize)
           .OrderBy(x => x.Id)
           .ToListAsync(cancellationToken);

        foreach (var document in queuedDocuments)
            document.RecognitionStatus = RecognitionStatus.Processing;

        await _context.SaveChangesAsync(cancellationToken);

        var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        foreach (var document in queuedDocuments)
        {
            try
            {
                using var httpClient = _httpClientFactory.CreateClient();

                using var httpResponse = await httpClient
                   .GetAsync(document.DownloadUrl, cancellationToken);

                var contentType = httpResponse.Content.Headers.ContentType?.MediaType;

                RecognitionException.ThrowIfNull(
                    contentType,
                    $"Не удалось определить тип файла для документа с id {document.Id}");

                var recognizer = _recognitionFactory.Create(contentType);

                await using var fileContent = await httpResponse.Content.ReadAsStreamAsync(cancellationToken);

                var recognizedContent = await recognizer.RecognizeAsync(fileContent, cancellationToken);

                var recognitionResult = new Entities.RecognitionResult
                {
                    DocumentId = document.Id,
                    Content = PreprocessText(recognizedContent)
                };

                _session.Store(recognitionResult);
                await _session.SaveChangesAsync(cancellationToken);

                document.RecognitionStatus = RecognitionStatus.Success;
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Возникла ошибка при распознавании документа с id {Id}", document.Id);
                document.RecognitionStatus = RecognitionStatus.Error;
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        return transaction;
    }

    private static string PreprocessText(RecognitionResult recognizedContent)
    {
        var joinedText = string.Join(' ', recognizedContent.Pages.Select(x => x.Text));
        return joinedText.Replace("\u0000", "");
    }
}
