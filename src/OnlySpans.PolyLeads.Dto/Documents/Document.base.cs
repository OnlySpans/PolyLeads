namespace OnlySpans.PolyLeads.Dto.Documents;

public abstract record DocumentBase
{
    public required long Id { get; init; }

    public required string Name { get; init; }

    public required string Description { get; init; }

    public required Uri DownloadUrl { get; init; }

    public required int FileRecognitionStatus { get; init; }

    public required string Resource { get; init; }
}
