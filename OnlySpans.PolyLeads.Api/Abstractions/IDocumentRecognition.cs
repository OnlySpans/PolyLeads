namespace OnlySpans.PolyLeads.Api.Abstractions;

public interface IDocumentRecognition
{
    Task RecognizeAsync(
        Stream document,
        CancellationToken cancellationToken = new());
}
