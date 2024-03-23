using Serilog;

namespace OnlySpans.PolyLeads.ReverseProxy;

public static class Startup
{
    public static Task<WebApplicationBuilder> ConfigureServices(this WebApplicationBuilder builder)
    {
        builder
           .AddServiceDefaults()
           .AddReverseProxy()
           .AddLogging();

        return Task.FromResult(builder);
    }

    public static Task<WebApplication> Configure(this WebApplication app)
    {
        app.MapReverseProxy();
        app.UseStaticFiles();

        return Task.FromResult(app);
    }

    #region WebApplicationBuilder | Add.*

    private static WebApplicationBuilder AddReverseProxy(this WebApplicationBuilder builder)
    {
        builder
           .Services
           .AddReverseProxy()
           .LoadFromConfig(
                builder
                   .Configuration
                   .GetSection("ReverseProxy"))
           .AddServiceDiscoveryDestinationResolver();

        return builder;
    }

    private static WebApplicationBuilder AddLogging(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((_, configuration) =>
        {
            configuration.ReadFrom.Configuration(builder.Configuration);
        });

        return builder;
    }

    #endregion

    #region WebApplicationBuilder | public deps

    /// <summary>
    /// Configures Log.Logger
    /// Must be called in `Program`
    /// </summary>
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

    #endregion
}
