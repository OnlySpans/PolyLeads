using OnlySpans.PolyLeads.Api.Pipelines;

namespace OnlySpans.PolyLeads.Api.Startup;

public static partial class Startup
{
    private static WebApplicationBuilder AddApiMediator(this WebApplicationBuilder builder)
    {
        builder.Services.AddApiMediator();

        return builder;
    }

    public static IServiceCollection AddApiMediator(this IServiceCollection services)
    {
        services.AddMediator();

        return services;
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