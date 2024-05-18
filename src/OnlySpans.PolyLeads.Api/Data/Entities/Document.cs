using OnlySpans.PolyLeads.Api.Data.Abstractions.Entities;
using OnlySpans.PolyLeads.Api.Data.Enums;

namespace OnlySpans.PolyLeads.Api.Data.Entities;

public class Document :
    IEntity<long>,
    IHasCreationInfo,
    IHasUpdateInfo,
    ISoftDeletable
{
    public long Id { get; set; } = 0;

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Uri DownloadUrl { get; set; } = default!;

    public long SourceId { get; set; } = 0;

    public RecognitionStatus RecognitionStatus { get; set; } = RecognitionStatus.Unknown;

    public DateTime CreatedAt { get; set; } = default!;

    public Guid CreatedById { get; set; } = Guid.Empty;


    public DateTime? UpdatedAt { get; set; }

    public Guid? UpdatedById { get; set; }


    public DateTime? DeletedAt { get; set; }

    public Guid? DeletedById { get; set; }

    public virtual ApplicationUser CreatedBy { get; set; } = default!;

    public virtual ApplicationUser? UpdatedBy { get; set; }

    public virtual ApplicationUser? DeletedBy { get; set; }

    public virtual PermittedSource Source { get; set; } = default!;
}
