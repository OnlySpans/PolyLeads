namespace OnlySpans.PolyLeads.Api.Data.Entities;

public class StorageObject
{
    public long Id { get; set; } = 0;

    public string StorageAlias { get; set; } = string.Empty;

    public string StorageId { get; set; } = string.Empty;

    public virtual FileEntry FileEntry { get; set; } = default!;
}
