using OnlySpans.PolyLeads.Api.Abstractions.Recognition;
using OnlySpans.PolyLeads.Api.Data.Records.Recognition;
using Spire.Doc;

namespace OnlySpans.PolyLeads.Api.Services.Recognition;

public sealed class SearchableDocxRecognition :
    IDocumentRecognition
{
    public Task<RecognitionResult> RecognizeAsync(
        Stream document,
        CancellationToken cancellationToken = new())
    {
        using var docxDocument = new Document(document, FileFormat.Auto);

        var page = new RecognitionPage(1, docxDocument.GetText());

        var recognitionResult = new RecognitionResult([page]);

        return Task.FromResult(recognitionResult);
    }
}
