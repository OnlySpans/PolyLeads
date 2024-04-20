using OnlySpans.PolyLeads.Api.Data.Abstractions;

namespace OnlySpans.PolyLeads.Api.Data.Entities;

public class Document :
    IHasCreationInfo,
    IHasUpdateInfo,
    ISoftDeletable
{
    public long Id { get; set; } = 0;

     public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Uri Link { get; set; } = default!;

    public DateTime CreatedAt { get; init; } = default!;

    public Guid CreatedBy { get; init; } = Guid.Empty;


    public DateTime UpdatedAt { get; init; } = default!;

    public Guid UpdatedBy { get; init; } = Guid.Empty;


    public DateTime? DeletedAt { get; init; }

    public Guid? DeletedBy { get; init; }
}
