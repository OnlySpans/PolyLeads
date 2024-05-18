namespace OnlySpans.PolyLeads.Dto.Documents;

public sealed record EditDocumentInput
{
    public required string Name { get; init; }

    public required string Description { get; init; }
}
