namespace OnlySpans.PolyLeads.Api.Schema.Inputs.Auth;

[GraphQLDescription("Никнейм")]
public sealed record UserName : ISignInKey
{
    [GraphQLDescription("Значение")]
    public string Value { get; init; } = string.Empty;
}