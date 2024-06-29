namespace OnlySpans.PolyLeads.Api.Abstractions.LLM;

public interface ILLMClient
{
    Task<Stream> GenerateResponseAsync(
        string prompt,
        CancellationToken cancellationToken = new());
}