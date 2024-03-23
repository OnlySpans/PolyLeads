using OnlySpans.PolyLeads.Api.Schema.Inputs.Files;

namespace OnlySpans.PolyLeads.Api.Schema.Inputs.Documents;

[GraphQLDescription("Данные, необходимые для создания группы документов")]
public sealed record NewDocumentGroupInput
{
    [GraphQLDescription("Название")]
    public string Name { get; init; } = string.Empty;

    [GraphQLDescription("Описание")]
    public string Description { get; init; } = string.Empty;

    [GraphQLDescription("Файлы")]
    public Optional<IReadOnlyList<CreateFileInput>?> Files { get; init; } = default!;

    [GraphQLDescription("Новые группы документов")]
    public Optional<IReadOnlyList<NewDocumentGroupInput>?> Groups { get; init; } = default!;
}