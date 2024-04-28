namespace OnlySpans.PolyLeads.Api.Data.Entities;

public class RecognitionStatus
{
    public long Id { get; set; } = 0;
    
    public DateTime AssignedAt { get; set; } = default!;

    public Enums.RecognitionStatus Value { get; set; } = Enums.RecognitionStatus.Unknown;

}