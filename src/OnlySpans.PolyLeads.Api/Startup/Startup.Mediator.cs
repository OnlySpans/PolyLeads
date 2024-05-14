using System.Reflection;

namespace OnlySpans.PolyLeads.Api.Startup;

public static class MediatorExtensions
{
    public static WebApplicationBuilder AddMediatR(this WebApplicationBuilder builder)
    {
        builder
           .Services
           .AddMediatR(config =>
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return builder;
    }
}
