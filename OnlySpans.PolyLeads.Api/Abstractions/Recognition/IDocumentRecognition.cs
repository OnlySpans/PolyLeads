using OnlySpans.PolyLeads.Api.Data.Records.Recognition;

namespace OnlySpans.PolyLeads.Api.Abstractions.Recognition;

public interface IDocumentRecognition
{
    Task<RecognitionResult> RecognizeAsync(
        Stream document,
        CancellationToken cancellationToken = new());
}
