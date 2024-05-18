using OnlySpans.PolyLeads.Api.Data.Abstractions.Options;

namespace OnlySpans.PolyLeads.Api.Data.Options;

public sealed record MasterRoleOptions :
    IApplicationOptions
{
    public static string Section { get; } = "MasterRole";

    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public string UserName { get; init; } = string.Empty;

    public string Password { get; init; } = string.Empty;

    public string Role { get; init; } = string.Empty;
}
