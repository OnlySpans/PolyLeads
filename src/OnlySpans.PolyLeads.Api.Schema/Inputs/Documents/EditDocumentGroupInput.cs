using OnlySpans.PolyLeads.Api.Schema.Inputs.Files;

namespace OnlySpans.PolyLeads.Api.Schema.Inputs.Documents;

[GraphQLDescription("Данные, необходимые для изменения группы документов")]
public sealed record EditDocumentGroupInput
{
    [GraphQLDescription("Идентификатор существующей группы документов")]
    public long Id { get; init; } = 0;

    [GraphQLDescription("Новое название")] 
    public Optional<string?> Name { get; init; } = default!;

    [GraphQLDescription("Новое описание")]
    public Optional<string?> Description { get; init; } = default!;

    [GraphQLDescription("Новые файлы")]
    public Optional<IReadOnlyList<CreateFileInput>?> Files { get; init; } = default!;

    [GraphQLDescription("Новые группы документов")]
    public Optional<IReadOnlyList<NewDocumentGroupInput>?> Groups { get; init; } = default!;
}