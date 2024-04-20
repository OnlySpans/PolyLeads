namespace OnlySpans.PolyLeads.Dto.Data;

public sealed record Document
{
    public required string Name { get; init; }

    public required string Description { get; init; }

    public required Uri Link { get; init; }
}