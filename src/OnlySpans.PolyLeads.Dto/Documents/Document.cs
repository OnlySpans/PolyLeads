namespace OnlySpans.PolyLeads.Dto.Documents;

public sealed record Document : DocumentBase
{
    public required string CreatedBy { get; init; }

    public required DateTime CreatedAt { get; init; }
}
