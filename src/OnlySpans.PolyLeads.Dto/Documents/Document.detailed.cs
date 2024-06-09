namespace OnlySpans.PolyLeads.Dto.Documents;

public sealed record DetailedDocument : DocumentBase
{

    public required DateTime CreatedAt { get; init; }
    public required string CreatedByUser { get; init; }


    public required DateTime UpdatedAt { get; init; }
    public required string UpdatedByUser { get; init; }


    public required DateTime? DeletedAt { get; init; }
    public required string? DeletedByUser { get; init; }
}
