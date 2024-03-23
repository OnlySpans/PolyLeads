namespace OnlySpans.PolyLeads.Api.Schema.Inputs.Auth;

[GraphQLDescription("Данные, необходимые для создания нового аккаунта")]
public sealed record SignUpInput
{
    [GraphQLDescription("Имя пользователя")]
    public string FirstName { get; init; } = string.Empty;

    [GraphQLDescription("Фамилия пользователя")]
    public string LastName { get; init; } = string.Empty;

    [GraphQLDescription("Отчество пользователя")]
    public Optional<string?> Patronymic { get; init; } = default!;

    [GraphQLDescription("Никнейм пользователя")]
    public string UserName { get; init; } = string.Empty;

    [GraphQLDescription("Почта пользователя")]
    public string Email { get; init; } = string.Empty;

    [GraphQLDescription("Пароль от аккаунта")]
    public string Password { get; init; } = string.Empty;
}