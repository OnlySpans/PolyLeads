namespace OnlySpans.PolyLeads.Api.Data.Entities;

public class PermittedSource
{
    public long Id { get; set; } = 0;

    public Uri BaseUrl { get; set; } = default!;

    public string Description { get; set; } = string.Empty;
}