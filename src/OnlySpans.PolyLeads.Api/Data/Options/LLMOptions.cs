using OnlySpans.PolyLeads.Api.Data.Abstractions.Options;

namespace OnlySpans.PolyLeads.Api.Data.Options;

public sealed record LLMOptions : IApplicationOptions
{
    public static string Section { get; } = "LLM";

    public string ApiKey { get; init; } = string.Empty;

    public string FolderId { get; init; } = string.Empty;

    public string ModelId { get; init; } = string.Empty;

    public string RequestUri { get; init; } = string.Empty;

    public string SystemPrompt { get; init; } = string.Empty;

    public float Temperature { get; init; } = 0;

    public int MaxResponseTokens { get; init; } = 0;
}