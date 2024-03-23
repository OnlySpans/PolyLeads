namespace OnlySpans.PolyLeads.Api.Schema.Payloads.Documents;

[GraphQLDescription("Группа документов")]
public sealed record DocumentGroup
{
    [GraphQLDescription("Идентификатор")] 
    public long Id { get; init; } = 0;

    [GraphQLDescription("Название")] 
    public string Name { get; init; } = string.Empty;

    [GraphQLDescription("Описание")]
    public string Description { get; init; } = string.Empty;

    [GraphQLDescription("Дата создания")]
    public DateTime CreatedAt { get; init; } = DateTime.MinValue;

    [GraphQLDescription("ФИО пользователя, создавшего группу документов")]
    public string CreatedBy { get; init; } = string.Empty;

    [GraphQLDescription("Дата последнего изменения")]
    public DateTime UpdatedAt { get; init; } = DateTime.MinValue;

    [GraphQLDescription("ФИО пользователя, в последний раз изменившего группу документов")]
    public string UpdatedBy { get; init; } = string.Empty;

    [GraphQLDescription("Другие группы документов, находящиеся внутри")]
    public IReadOnlyList<DocumentGroup> Groups { get; init; } = [];

    [GraphQLDescription("Документы")] 
    public IReadOnlyList<Document> Documents { get; init; } = [];
}