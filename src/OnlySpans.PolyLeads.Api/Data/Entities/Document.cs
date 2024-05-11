namespace OnlySpans.PolyLeads.Api.Data.Entities;

public class Document
{
    public long Id { get; set; } = 0;

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Uri Link { get; set; } = default!;

    public DateTime CreatedAt { get; init; } = default!;

    public Guid CreatedById { get; init; } = Guid.Empty;


    public DateTime UpdatedAt { get; set; } = default!;

    public Guid UpdatedById { get; set; } = Guid.Empty;


    public DateTime? DeletedAt { get; set; }

    public Guid? DeletedById { get; set; }

    public virtual ApplicationUser CreatedBy { get; init; } = default!;

    public virtual ApplicationUser UpdatedBy { get; set; } = default!;

    public virtual ApplicationUser? DeletedBy { get; set; } = default!;
}