namespace OnlySpans.PolyLeads.Api.Startup;

public static partial class Startup
{
    private static WebApplicationBuilder AddHttpClient(this WebApplicationBuilder builder)
    {
        builder
           .Services
           .AddHttpClient();

        return builder;
    }

}
