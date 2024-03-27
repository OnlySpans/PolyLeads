namespace OnlySpans.PolyLeads.Api.Schema.Inputs.Auth;

[GraphQLDescription("Почта")]
public sealed record Email : IAuthKey
{
    [GraphQLDescription("Значение")]
    public string EmailValue { get; init; } = string.Empty;
}
