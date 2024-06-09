namespace OnlySpans.PolyLeads.Api.Startup;

public static partial class Startup
{
    private static WebApplicationBuilder AddMediator(this WebApplicationBuilder builder)
    {
        builder
           .Services
           .AddMediator();

        return builder;
    }
}