namespace OnlySpans.PolyLeads.Dto.Documents;

public sealed record Document
{
    public required string Name { get; init; }

    public required string Description { get; init; }

    public required Uri DownloadUrl { get; init; }
}
