namespace OnlySpans.PolyLeads.Api.Data.Abstractions.Options;

public interface IApplicationOptions
{
    protected static string Root { get; } = "";

    static abstract string Section { get; }
}
