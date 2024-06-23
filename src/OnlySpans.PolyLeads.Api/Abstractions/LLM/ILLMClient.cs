namespace OnlySpans.PolyLeads.Api.Abstractions.LLM;

public interface ILLMClient
{
    Task<Stream> GenerateResponseAsync(
        string userPrompt,
        IReadOnlyList<string> documentsContent,
        CancellationToken cancellationToken = new());
}