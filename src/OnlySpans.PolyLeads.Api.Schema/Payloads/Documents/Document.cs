using HotChocolate;
using OnlySpans.PolyLeads.Api.Schema.Payloads.Files;

namespace OnlySpans.PolyLeads.Api.Schema.Payloads.Documents;

[GraphQLDescription("Документ - представляет из себя файл с дополнительной информацией сверху")]
public sealed record Document
{
    [GraphQLDescription("Идентификатор")] 
    public long Id { get; init; } = 0;

    [GraphQLDescription("Название")] 
    public string Name { get; init; } = string.Empty;

    [GraphQLDescription("Описание")]
    public string Description { get; init; } = string.Empty;

    [GraphQLDescription("""
                        Статус распознавания текста:
                        0 - неизвестен
                        1 - в очереди
                        2 - выполняется
                        3 - текст успешно распознан
                        4 - при распозновании текста произошла ошибка
                        """)]
    public int RecognitionStatus { get; init; } = 0;

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
