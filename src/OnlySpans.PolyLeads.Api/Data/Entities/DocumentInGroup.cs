using OnlySpans.PolyLeads.Api.Data.Abstractions;

namespace OnlySpans.PolyLeads.Api.Data.Entities;

public class DocumentInGroup : ISoftDeletable
{
    public long DocumentId { get; set; } = 0;

    public long DocumentGroupId { get; set; } = 0;


    public DateTime? DeletedAt { get; init; }

    public Guid? DeletedBy { get; init; }


    public virtual Document Document { get; set; } = default!;

    public virtual DocumentGroup DocumentGroup { get; set; } = default!;
}
