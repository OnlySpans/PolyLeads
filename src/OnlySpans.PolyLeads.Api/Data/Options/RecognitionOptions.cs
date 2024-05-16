using OnlySpans.PolyLeads.Api.Data.Abstractions.Options;

namespace OnlySpans.PolyLeads.Api.Data.Options;

public sealed record RecognitionOptions : IApplicationOptions
{
    public static string Section { get; } = "Recognition";

    public int FilesBatchSize { get; init; } = 10;

    public string Cron { get; init; } = "*/5 * * * *";
}
