using OnlySpans.PolyLeads.Api.Workers;

namespace OnlySpans.PolyLeads.Api.Startup;

public static partial class Startup
{
    private static WebApplicationBuilder AddWorkers(this WebApplicationBuilder builder)
    {
        builder
           .Services
           .AddHostedService<RecognitionWorkerRunner>();

        return builder;
    }
}
