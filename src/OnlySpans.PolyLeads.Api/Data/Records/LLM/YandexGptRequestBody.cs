namespace OnlySpans.PolyLeads.Api.Data.Records.LLM;

public sealed record YandexGptRequestBody
{
    public string ModelUri { get; init; } = string.Empty;

    public CompletionOptions CompletionOptions { get; init; } = default!;
    
    public List<Message> Messages { get; init; } = default!;
}