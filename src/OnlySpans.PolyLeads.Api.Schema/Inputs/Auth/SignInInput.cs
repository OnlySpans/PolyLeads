namespace OnlySpans.PolyLeads.Api.Schema.Inputs.Auth;

[GraphQLDescription("Данные, необходимые для авторизации пользователя")]
public sealed record SignInInput
{
    [GraphQLDescription("Ключ для идентификации пользователя, может быть почтой или никнеймом")]
    public string Key { get; init; } = string.Empty;

    [GraphQLDescription("Пароль от аккаунта")]
    public string Password { get; init; } = string.Empty;
}
 