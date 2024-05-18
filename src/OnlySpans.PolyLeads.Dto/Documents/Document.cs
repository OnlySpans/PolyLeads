namespace OnlySpans.PolyLeads.Dto.Documents;

public sealed record Document : DocumentBase
{
    public required string CreatedByUser { get; init; }
}
