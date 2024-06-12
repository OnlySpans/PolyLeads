using OnlySpans.PolyLeads.Api.Pipelines;

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
    
    private static WebApplicationBuilder AddMediatorPipeline(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(CalledByUserPipeline<,>));

        return builder;
    }
}