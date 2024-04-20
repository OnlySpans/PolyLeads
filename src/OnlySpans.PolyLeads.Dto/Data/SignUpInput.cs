namespace OnlySpans.PolyLeads.Dto.Data;

public sealed record SignUpInput    
{
    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public required string UserName { get; init; }

    public required string Password { get; init; }
}