namespace OnlySpans.PolyLeads.Api.Data.Records.LLM;

public sealed record Message
{
    public string Role { get; init; } = string.Empty;

    public string Text { get; init; } = string.Empty;
}