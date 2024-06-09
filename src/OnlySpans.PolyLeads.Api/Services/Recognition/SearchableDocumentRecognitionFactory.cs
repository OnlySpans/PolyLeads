using OnlySpans.PolyLeads.Api.Abstractions.Recognition;
using OnlySpans.PolyLeads.Api.Exceptions;

namespace OnlySpans.PolyLeads.Api.Services.Recognition;

public sealed class SearchableDocumentRecognitionFactory :
    IDocumentRecognitionFactory
{
    public IDocumentRecognition Create(string mimeType) =>
        mimeType switch
        {
            "application/pdf" =>
                new SearchablePdfRecognition(),
            "application/vnd.openxmlformats-officedocument.wordprocessingml.document" =>
                new SearchableDocxRecognition(),
            _ => throw new UnsupportedRecognitionFileTypeException(mimeType)
        };
}
