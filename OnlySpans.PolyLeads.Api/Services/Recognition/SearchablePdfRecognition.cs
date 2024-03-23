using OnlySpans.PolyLeads.Api.Abstractions.Recognition;
using OnlySpans.PolyLeads.Api.Data.Records.Recognition;
using UglyToad.PdfPig;

namespace OnlySpans.PolyLeads.Api.Services.Recognition;

public sealed class SearchablePdfRecognition :
    IDocumentRecognition
{
    public Task<RecognitionResult> RecognizeAsync(
        Stream document,
        CancellationToken cancellationToken = new())
    {
        using var pdfDocument = PdfDocument.Open(document);

        var pages = pdfDocument
           .GetPages()
           .Select(x => new RecognitionPage(x.Number, x.Text))
           .ToList();

        var recognitionResult = new RecognitionResult(pages);

        return Task.FromResult(recognitionResult);
    }
}
