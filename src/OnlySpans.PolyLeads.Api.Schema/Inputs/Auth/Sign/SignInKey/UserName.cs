namespace OnlySpans.PolyLeads.Api.Schema.Inputs.Auth.Sign.SignInKey;

[GraphQLDescription("Никнейм")]
public sealed record UserName : ISignInKey
{
    [GraphQLDescription("Значение")]
    public string Value { get; init; } = string.Empty;
}