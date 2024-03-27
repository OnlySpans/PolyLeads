namespace OnlySpans.PolyLeads.Api.Schema.Inputs.Auth;

[GraphQLDescription("Почта")]
public sealed record Email
{
    [GraphQLDescription("Значение")]
    public string EmailValue { get; init; } = string.Empty;
}
