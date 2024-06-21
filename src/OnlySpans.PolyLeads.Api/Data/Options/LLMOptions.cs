using OnlySpans.PolyLeads.Api.Data.Abstractions.Options;

namespace OnlySpans.PolyLeads.Api.Data.Options;

public sealed record LLMOptions() : IApplicationOptions
{
    public static string Section { get; } = "LLM";

    public static string ApiKey { get; } = string.Empty;

    public static string ModelUri { get; } = string.Empty;

    public static string RequestUri { get; } = string.Empty;

    public static float Temperature { get; } = 0;

    public static int MaxResponseTokens { get; } = 0;
}