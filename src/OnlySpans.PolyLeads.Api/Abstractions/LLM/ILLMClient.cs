namespace OnlySpans.PolyLeads.Api.Abstractions.LLM;

public interface ILLMClient
{
    Task<Stream> GenerateResponseAsync(
        string userPrompt,
        string documents,
        CancellationToken cancellationToken = new());
}