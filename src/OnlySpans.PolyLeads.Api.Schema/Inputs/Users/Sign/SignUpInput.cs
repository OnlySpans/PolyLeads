using HotChocolate;
using OnlySpans.PolyLeads.Api.Schema.Inputs.Users.Sign.SignInKey;

namespace OnlySpans.PolyLeads.Api.Schema.Inputs.Users.Sign;

[GraphQLDescription("Данные, необходимые для создания нового аккаунта")]
public sealed record SignUpInput
{
    [GraphQLDescription("Имя пользователя")]
    public string FirstName { get; init; } = string.Empty;

    [GraphQLDescription("Фамилия пользователя")]
    public string LastName { get; init; } = string.Empty;

    [GraphQLDescription("Отчество пользователя")]
    public string Patronymic { get; init; } = string.Empty;

    [GraphQLDescription("Никнейм пользователя")]
    public UserName UserName { get; init; } = default!;

    [GraphQLDescription("Почта пользователя")]
    public Email Email { get; init; } = default!;

    [GraphQLDescription("Пароль от аккаунта")]
    public string Password { get; init; } = string.Empty;
}