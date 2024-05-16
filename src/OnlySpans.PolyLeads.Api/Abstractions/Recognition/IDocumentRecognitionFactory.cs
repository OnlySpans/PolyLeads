namespace OnlySpans.PolyLeads.Api.Abstractions.Recognition;

public interface IDocumentRecognitionFactory
{
    IDocumentRecognition Create(string mimeType);
}