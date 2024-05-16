namespace OnlySpans.PolyLeads.Api.Data.Entities;

public class RecognitionResult
{
    public long Id { get; set; } = 0;

    public long DocumentId { get; set; } = 0;

    public string Content { get; set; } = string.Empty;
}
