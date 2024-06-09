namespace OnlySpans.PolyLeads.Dto.Roles;

public sealed record GrantRoleInput
{
    public required string UserName { get; init; }

    public required string RoleName { get; init; }
}
