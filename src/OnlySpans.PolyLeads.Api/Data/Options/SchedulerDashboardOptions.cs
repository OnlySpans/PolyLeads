using OnlySpans.PolyLeads.Api.Data.Abstractions.Options;

namespace OnlySpans.PolyLeads.Api.Data.Options;

public sealed record SchedulerDashboardOptions :
    IApplicationOptions
{
    public static string Section { get; } = "SchedulerDashboard";

    public string Login { get; init; } = string.Empty;

    public string Password { get; init; } = string.Empty;

    public bool Enabled { get; init; } = false;
}
