namespace OnlySpans.PolyLeads.Dto.Data;

public sealed record DetailedDocument
{
    public required long Id { get; init; }

    public required string Name { get; init; }

    public required string Description { get; init; }

    public required Uri Link { get; init; }


    public required DateTime CreatedAt { get; init; }

    public required string CreatedByUser { get; init; }


    public required DateTime UpdatedAt { get; init; }

    public required string UpdatedByUser { get; init; }


    public required DateTime? DeletedAt { get; init; }

    public required string? DeletedByUser { get; init; }
}