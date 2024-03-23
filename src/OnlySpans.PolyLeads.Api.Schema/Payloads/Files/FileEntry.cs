using HotChocolate;

namespace OnlySpans.PolyLeads.Api.Schema.Payloads.Files;

[GraphQLDescription("Файл с информацией о его создании")]
public sealed record FileEntry : FileEntryWithoutCreateInfo
{
    [GraphQLDescription("Дата создания")] 
    public DateTime CreatedAt { get; init; } = DateTime.MinValue;

    [GraphQLDescription("ФИО пользователя, создавшего файл")]
    public string CreatedBy { get; init; } = string.Empty;
}