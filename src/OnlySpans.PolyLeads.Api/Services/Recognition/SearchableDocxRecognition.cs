using Spire.Doc;

namespace OnlySpans.PolyLeads.Api.Services.Recognition;

public sealed class SearchableDocxRecognition
{
    public Task<string> RecognizeAsync(
        Stream document,
        CancellationToken cancellationToken = new())
    {
        using var docxDocument = new Document(document, FileFormat.Docx);
        
        var text = docxDocument.GetText();

        return Task.FromResult(text);
    }
}