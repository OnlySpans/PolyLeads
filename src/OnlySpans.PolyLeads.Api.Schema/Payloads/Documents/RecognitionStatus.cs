namespace OnlySpans.PolyLeads.Api.Schema.Payloads.Documents;

[GraphQLDescription("Статус распознавания текста")]
public enum RecognitionStatus
{
    [GraphQLDescription("Неизвестен")]
    Unknown = 0,

    [GraphQLDescription("В очереди")]
    Queued = 1,

    [GraphQLDescription("Выполняется")]
    Processing = 2,

    [GraphQLDescription("Текст успешно распознан")]
    Success = 3,

    [GraphQLDescription("При распозновании текста произошла ошибка")]
    Error = 4
}