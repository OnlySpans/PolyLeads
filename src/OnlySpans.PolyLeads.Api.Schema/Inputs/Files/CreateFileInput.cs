using HotChocolate;

namespace OnlySpans.PolyLeads.Api.Schema.Inputs.Files;

[GraphQLDescription("Данные, необходимые для создания файла")]
public sealed record CreateFileInput
{
    [GraphQLDescription("Название с расширением")]
    public string Name { get; init; } = string.Empty;

    [GraphQLDescription("Информация о расположении файла в хранилище")]
    public StorageObject StoredAt { get; init; } = default!;
}

[GraphQLDescription("Информация о расположении объекта в хранилище")]
public sealed record StorageObject
{
    [GraphQLDescription("Псевдоним хранилища")]
    public string StorageAlias { get; init; } = string.Empty;

    [GraphQLDescription("Идентификатор внутри хранилища")]
    public string StorageId { get; init; } = string.Empty;
}