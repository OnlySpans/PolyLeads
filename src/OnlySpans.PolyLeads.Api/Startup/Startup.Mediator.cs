using System.Reflection;

namespace OnlySpans.PolyLeads.Api.Startup;

public static partial class Startup
{
    private static WebApplicationBuilder AddMediatR(this WebApplicationBuilder builder)
    {
        builder
           .Services
           .AddMediatR(config =>
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return builder;
    }
}
