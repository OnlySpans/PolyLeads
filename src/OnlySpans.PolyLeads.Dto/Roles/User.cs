namespace OnlySpans.PolyLeads.Dto.Roles;

public sealed record User
{
    public required string FirstName { get; init; }
    
    public required string LastName { get; init; }
    
    public required string UserName { get; init; }

    public required string Role { get; init; }
}