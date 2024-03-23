using HotChocolate;

namespace OnlySpans.PolyLeads.Api.Schema.Inputs.Users.Sign.SignInKey;

[GraphQLDescription("Почта пользователя - необходима для входа в аккаунт")]
public sealed record Email : ISignInKey
{
    [GraphQLDescription("Значение почты")]
    public string Value { get; init; } = string.Empty;
}