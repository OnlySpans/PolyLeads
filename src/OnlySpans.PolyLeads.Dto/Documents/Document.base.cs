namespace OnlySpans.PolyLeads.Dto.Documents;

public abstract record DocumentBase
{
    public required string Name { get; init; }

    public required string Description { get; init; }

    public required Uri DownloadUrl { get; init; }

    public required int RecognitionStatus { get; init; }

    public required string Source { get; init; }
}
