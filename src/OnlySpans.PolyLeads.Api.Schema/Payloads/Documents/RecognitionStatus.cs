namespace OnlySpans.PolyLeads.Api.Schema.Payloads.Documents;

[GraphQLDescription(
    """
    Статус распознавания текста:
    0 - неизвестен
    1 - в очереди
    2 - выполняется
    3 - текст успешно распознан
    4 - при распозновании текста произошла ошибка
    """)]
public enum RecognitionStatus
{
    Unknown,
    Queued,
    Processing,
    Success,
    Error
}