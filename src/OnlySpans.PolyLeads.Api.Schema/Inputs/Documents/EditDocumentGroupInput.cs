using HotChocolate;
using OnlySpans.PolyLeads.Api.Schema.Inputs.Files;

namespace OnlySpans.PolyLeads.Api.Schema.Inputs.Documents;

[GraphQLDescription("Данные, необходимые для изменения группы документов")]
public sealed record EditDocumentGroupInput
{
    [GraphQLDescription("Идентификатор существующей группы документов")]
    public long Id { get; init; } = 0;

    [GraphQLDescription("Новое название")] 
    public string Name { get; init; } = string.Empty;

    [GraphQLDescription("Новое описание")]
    public string Description { get; init; } = string.Empty;

    [GraphQLDescription("Новые файлы")]
    public IReadOnlyList<CreateFileInput>? Files { get; init; } = default;

    [GraphQLDescription("Новые группы документов")]
    public IReadOnlyList<NewDocumentGroupInput>? Groups { get; init; } = default;
}