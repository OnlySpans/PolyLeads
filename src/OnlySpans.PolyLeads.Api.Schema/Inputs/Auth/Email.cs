namespace OnlySpans.PolyLeads.Api.Schema.Inputs.Auth;

[GraphQLDescription("Почта")]
public sealed record Email : ISignInKey
{
    [GraphQLDescription("Значение")]
    public string Value { get; init; } = string.Empty;
}
