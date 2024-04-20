namespace OnlySpans.PolyLeads.Api.Schema.Inputs.Auth;

public sealed record SignUpInput
{
    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public string? Patronymic { get; init; } = default!;

    public string UserName { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;

    public string Password { get; init; } = string.Empty;
}