namespace OnlySpans.PolyLeads.Api.Data.Entities;

public class RecognitionResult
{
    public long Id { get; set; } = 0;

    public long FileEntryId { get; set; } = 0;

    public string AllText { get; set; } = string.Empty;

    public DateTime RecognizedAt { get; set; } = default!;

    public virtual FileEntry FileEntry { get; set; } = default!;
}
