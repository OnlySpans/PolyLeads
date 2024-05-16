using Marten;
using OnlySpans.PolyLeads.Api.Services.Logging;
using Serilog;

namespace OnlySpans.PolyLeads.Api.Startup;

public static partial class Startup
{
    private static WebApplicationBuilder AddLogging(this WebApplicationBuilder builder)
    {
        builder
           .Host
           .UseSerilog((_, configuration) =>
            {
                configuration.ReadFrom.Configuration(builder.Configuration);
            });

        builder
           .Services
           .AddSingleton<IMartenLogger, DefaultMartenLogger>();

        return builder;
    }

    public static WebApplicationBuilder ConfigureStaticLogger(this WebApplicationBuilder builder)
    {
        // always log to console as default behaviour
        var loggerConfiguration = new LoggerConfiguration()
           .WriteTo.Console()
           .ReadFrom
           .Configuration(builder.Configuration);

        Log.Logger = loggerConfiguration.CreateBootstrapLogger();

        return builder;
    }
}
