namespace OnlySpans.PolyLeads.Api.Schema.Payloads.Files;

[GraphQLDescription("Файл с информацией о его создании")]
public sealed record FileEntry
{
    [GraphQLDescription("Название без расширения")]
    public string Name { get; init; } = string.Empty;

    [GraphQLDescription("Расширение")]
    public string Extension { get; init; } = string.Empty;

    [GraphQLDescription("Размер в байтах")]
    public long Size { get; init; } = 0;

    [GraphQLDescription("URL для скачивания")]
    public string DownloadUrl { get; init; } = string.Empty;

    [GraphQLDescription("Дата создания")] 
    public DateTime CreatedAt { get; init; } = DateTime.MinValue;

    [GraphQLDescription("ФИО пользователя, создавшего файл")]
    public string CreatedBy { get; init; } = string.Empty;
}