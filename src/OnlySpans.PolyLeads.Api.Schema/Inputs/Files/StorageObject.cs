namespace OnlySpans.PolyLeads.Api.Schema.Inputs.Files;

[GraphQLDescription("Информация о расположении объекта в хранилище")]
public sealed record StorageObject
{
    [GraphQLDescription("Псевдоним хранилища")]
    public string StorageAlias { get; init; } = string.Empty;

    [GraphQLDescription("Идентификатор внутри хранилища")]
    public string StorageId { get; init; } = string.Empty;
}