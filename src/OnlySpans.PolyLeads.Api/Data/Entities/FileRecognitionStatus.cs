namespace OnlySpans.PolyLeads.Api.Data.Entities;

public class FileRecognitionStatus
{
    public long Id { get; set; } = 0;

    public long FileEntryId { get; set; } = 0;

    public DateTime AssignedAt { get; set; } = default!;

    public RecognitionStatus Value { get; set; } = RecognitionStatus.Unknown;

    public virtual FileEntry FileEntry { get; set; } = default!;
}

public enum RecognitionStatus
{
    Unknown = 0,
    Queued = 1,
    Processing = 2,
    Success = 3,
    Error = 4
}
