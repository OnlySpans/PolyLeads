namespace OnlySpans.PolyLeads.Api.Schema.Inputs.Files;

[GraphQLDescription("Данные, необходимые для создания файла")]
public sealed record CreateFileInput
{
    [GraphQLDescription("Название с расширением")]
    public string Name { get; init; } = string.Empty;

    [GraphQLDescription("Информация о расположении файла в хранилище")]
    public StorageObject StoredAt { get; init; } = default!;
}