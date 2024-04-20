namespace OnlySpans.PolyLeads.Api.Schema.Inputs.Auth;

public sealed record SignInInput
{
    public string Key { get; init; } = string.Empty;

    public string Password { get; init; } = string.Empty;
}