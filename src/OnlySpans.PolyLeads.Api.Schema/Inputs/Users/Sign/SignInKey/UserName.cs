using HotChocolate;

namespace OnlySpans.PolyLeads.Api.Schema.Inputs.Users.Sign.SignInKey;

[GraphQLDescription("Никнейм пользователя - необходим для входа в аккаунт")]
public sealed record UserName : ISignInKey
{
    [GraphQLDescription("Значение никнейма")]
    public string Value { get; init; } = string.Empty;
}