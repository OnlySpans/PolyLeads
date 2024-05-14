namespace OnlySpans.PolyLeads.Api.Startup;

public static class EndpointsExtensions
{
    public static WebApplicationBuilder AddControllers(this WebApplicationBuilder builder)
    {
        builder
           .Services
           .AddControllers();

        return builder;
    }
}
