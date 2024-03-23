using OnlySpans.PolyLeads.Api.Data.Abstractions;

namespace OnlySpans.PolyLeads.Api.Data.Entities;

public class ChildGroup : ISoftDeletable
{
    public long ParentGroupId { get; set; } = 0;

    public long ChildGroupId { get; set; } = 0;


    public DateTime? DeletedAt { get; init; }

    public Guid? DeletedBy { get; init; }


    public virtual DocumentGroup Parent { get; set; } = default!;
    
    public virtual DocumentGroup Child { get; set; } = default!;
}
