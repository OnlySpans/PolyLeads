namespace OnlySpans.PolyLeads.Dto.Data;

public sealed record GiveRoleInput
{
    public required string UserName { get; init; }

    public required string RoleName { get; init; }
}