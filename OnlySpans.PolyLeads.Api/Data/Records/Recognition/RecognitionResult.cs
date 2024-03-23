namespace OnlySpans.PolyLeads.Api.Data.Records.Recognition;

public sealed record RecognitionResult(
    IReadOnlyList<RecognitionPage> Pages);
