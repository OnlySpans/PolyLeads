using HotChocolate;
using OnlySpans.PolyLeads.Api.Schema.Inputs.Users.Sign.SignInKey;

namespace OnlySpans.PolyLeads.Api.Schema.Inputs.Users.Sign;

[GraphQLDescription("Данные, необходимые для авторизации пользователя")]
public sealed record SignInInput
{
    [GraphQLDescription("Ключ для идентификации пользователя, может быть почтой или никнеймом")]
    public ISignInKey SignInKey { get; init; } = default!;

    [GraphQLDescription("Пароль от аккаунта")]
    public string Password { get; init; } = string.Empty;
}