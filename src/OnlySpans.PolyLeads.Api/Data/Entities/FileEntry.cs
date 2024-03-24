using OnlySpans.PolyLeads.Api.Data.Abstractions;

namespace OnlySpans.PolyLeads.Api.Data.Entities;

public class FileEntry :
    IHasCreationInfo,
    ISoftDeletable
{
    public long Id { get; set; } = 0;

    public string Name { get; set; } = string.Empty;

    public string Extension { get; set; } = string.Empty;

    public long Size { get; set; } = 0;

    public long StorageObjectId { get; set; } = 0;


    public DateTime CreatedAt { get; set; } = default!;

    public Guid CreatedBy { get; set; } = Guid.Empty;


    public DateTime? DeletedAt { get; set; }

    public Guid? DeletedBy { get; set; }


    public virtual StorageObject StorageObject { get; set; } = default!;

    public virtual Document Document { get; set; } = default!;

    public virtual ICollection<FileRecognitionStatus> RecognitionStatuses { get; set; } = [];

    public virtual ICollection<RecognitionResult> RecognitionResults { get; set; } = [];
}
