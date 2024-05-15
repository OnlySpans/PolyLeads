using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using OnlySpans.PolyLeads.Api.Abstractions.Recognition;
using OnlySpans.PolyLeads.Api.Data.Contexts;
using OnlySpans.PolyLeads.Api.Data.Enums;
using OnlySpans.PolyLeads.Api.Data.Options;
using OnlySpans.PolyLeads.Api.Exceptions;

namespace OnlySpans.PolyLeads.Api.Workers;

public sealed class RecognitionWorker : BackgroundService
{
    private IServiceScopeFactory ScopeFactory { get; init; }
    private ILogger<RecognitionWorker> Logger { get; init; }
    private IOptions<RecognitionOptions> Options { get; init; }
    private IHttpClientFactory HttpClientFactory { get; init; }
    private IDocumentRecognitionFactory RecognitionFactory { get; init; }

    public RecognitionWorker(
        IServiceScopeFactory scopeFactory,
        IOptions<RecognitionOptions> options,
        IHttpClientFactory httpClientFactory,
        IDocumentRecognitionFactory recognitionFactory,
        ILogger<RecognitionWorker> logger)
    {
        ScopeFactory = scopeFactory;
        Options = options;
        HttpClientFactory = httpClientFactory;
        RecognitionFactory = recognitionFactory;
        Logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await using var scope = ScopeFactory.CreateAsyncScope();

            var serviceProvider = scope.ServiceProvider;
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            await using var transaction = await context.Database.BeginTransactionAsync(stoppingToken);

            try
            {
                await RecognizeDocumentsAsync(
                    HttpClientFactory.CreateClient(),
                    context,
                    serviceProvider.GetRequiredService<Marten.IDocumentSession>(),
                    stoppingToken);

                await transaction.CommitAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Возникла ошибка при работе Worker'а с распознованием");
                await transaction.RollbackAsync(stoppingToken);
            }
        }
    }

    private async Task RecognizeDocumentsAsync(
        HttpClient httpClient,
        ApplicationDbContext context,
        Marten.IDocumentSession session,
        CancellationToken cancellationToken)
    {
        var queuedDocuments = await context
           .Documents
           .Where(x => x.RecognitionStatus == RecognitionStatus.Queued)
           .Take(Options.Value.FilesBatchSize)
           .ToListAsync(cancellationToken);

        foreach (var document in queuedDocuments)
            document.RecognitionStatus = RecognitionStatus.Processing;

        await context.SaveChangesAsync(cancellationToken);

        foreach (var document in queuedDocuments)
        {
            try
            {
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
                    Content = string.Join('\n', recognizedContent.Pages.Select(x => x.Text))
                };

                session.Store(recognitionResult);
                await session.SaveChangesAsync(cancellationToken);

                document.RecognitionStatus = RecognitionStatus.Success;
                await context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Возникла ошибка при распозновании документа с id {Id}", document.Id);
                document.RecognitionStatus = RecognitionStatus.Error;
                await context.SaveChangesAsync(cancellationToken);
                throw;
            }
        }
    }
}
