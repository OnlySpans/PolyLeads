namespace OnlySpans.PolyLeads.Api.Schema.Inputs.Auth.Sign.SignInKey;

[GraphQLDescription("Почта")]
public sealed record Email : ISignInKey
{
    [GraphQLDescription("Значение")]
    public string Value { get; init; } = string.Empty;
}