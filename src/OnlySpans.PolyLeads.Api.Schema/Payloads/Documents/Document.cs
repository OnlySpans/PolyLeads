using OnlySpans.PolyLeads.Api.Schema.Payloads.Files;

namespace OnlySpans.PolyLeads.Api.Schema.Payloads.Documents;

[GraphQLDescription("Документ")]
public sealed record Document
{
    [GraphQLDescription("Идентификатор")] 
    public long Id { get; init; } = 0;

    [GraphQLDescription("Название")] 
    public string Name { get; init; } = string.Empty;

    [GraphQLDescription("Описание")]
    public string Description { get; init; } = string.Empty;

    [GraphQLDescription("Статус распознавания текста")]
    public RecognitionStatus RecognitionStatus { get; init; } = RecognitionStatus.Unknown;

    [GraphQLDescription("Дата создания")]
    public DateTime CreatedAt { get; init; } = DateTime.MinValue;

    [GraphQLDescription("ФИО пользователя, создавшего документ")]
    public string CreatedBy { get; init; } = string.Empty;

    [GraphQLDescription("Дата последнего изменения")]
    public DateTime UpdatedAt { get; init; } = DateTime.MinValue;

    [GraphQLDescription("ФИО пользователя, в последний раз изменившего документ")]
    public string UpdatedBy { get; init; } = string.Empty;

    [GraphQLDescription("Файл (содержание документа)")]
    public FileEntryWithoutCreateInfo File { get; init; } = default!;
}
