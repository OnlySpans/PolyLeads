namespace OnlySpans.PolyLeads.Api.Schema.Payloads.Files;

[GraphQLDescription("Файл без информации о его создании")]
public sealed record FileEntryWithoutCreateInfo
{
    [GraphQLDescription("Название без расширения")]
    public string Name { get; init; } = string.Empty;

    [GraphQLDescription("Расширение")]
    public string Extension { get; init; } = string.Empty;

    [GraphQLDescription("Размер в байтах")]
    public long Size { get; init; } = 0;

    [GraphQLDescription("URL для скачивания")]
    public string DownloadUrl { get; init; } = string.Empty;
}