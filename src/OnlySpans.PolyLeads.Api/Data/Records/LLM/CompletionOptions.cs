namespace OnlySpans.PolyLeads.Api.Data.Records.LLM;

public sealed record CompletionOptions
{
    public bool Stream { get; init; }
    
    public float Temperature { get; init; }
    
    public int MaxTokens { get; init; }
}