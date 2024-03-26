namespace OnlySpans.PolyLeads.Api.Schema.Payloads.Auth;

public sealed record ApplicationUser
{
    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public string? Patronymic { get; init; }

    public string UserName { get; init; } = string.Empty;
}


    
