namespace OnlySpans.PolyLeads.Api.Schema.Inputs.Auth;

[GraphQLDescription("Никнейм")]
public sealed record UserName : IAuthKey
{
    [GraphQLDescription("Значение")]
    public string UserNameValue { get; init; } = string.Empty;
}