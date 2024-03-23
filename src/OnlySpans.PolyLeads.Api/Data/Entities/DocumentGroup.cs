using OnlySpans.PolyLeads.Api.Data.Abstractions;

namespace OnlySpans.PolyLeads.Api.Data.Entities;

public class DocumentGroup
    : IHasCreationInfo,
      IHasUpdateInfo,
      ISoftDeletable
{
    public long Id { get; set; } = 0;

    public long? ParentGroupId { get; set; } = 0;

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;


    public DateTime CreatedAt { get; init; } = default!;

    public Guid CreatedBy { get; init; } = Guid.Empty;


    public DateTime UpdatedAt { get; init; } = default!;

    public Guid UpdatedBy { get; init; } = Guid.Empty;


    public DateTime? DeletedAt { get; init; }

    public Guid? DeletedBy { get; init; }


    public virtual ICollection<DocumentInGroup> DocumentInGroups { get; set; } = new List<DocumentInGroup>();

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual DocumentGroup? ParentGroup { get; set; } = default!;

    public virtual ICollection<DocumentGroup> ChildGroups { get; set; } = new List<DocumentGroup>();
}
