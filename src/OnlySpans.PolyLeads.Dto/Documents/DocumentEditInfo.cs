namespace OnlySpans.PolyLeads.Dto.Documents;

public sealed record DocumentEditInfo
{
    public required string Name { get; init; }

    public required string Description { get; init; }
}
