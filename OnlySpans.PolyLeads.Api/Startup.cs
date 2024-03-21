using System.Reflection;
using Mapster;
using MapsterMapper;
using Marten;
using Npgsql;
using Serilog;
using Weasel.Core;


namespace OnlySpans.PolyLeads.Api;

public static class Startup
{
    public static Task<WebApplicationBuilder> ConfigureServices(this WebApplicationBuilder builder)
    {
        builder
           .AddMediatR()
           .AddControllers()
           .AddMarten()
           .AddLogging()
           .AddMapper()
           .AddHttpClient();

        return Task.FromResult(builder);
    }

    public static async Task<WebApplication> Configure(this WebApplication app)
    {
        app.UseExceptionHandler();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        // Otherwise SpaProxy won't work
        app.UseEndpoints(_ => { });

        app.UseDevelopmentSpaHost();
        app.MapControllers();

        return app;
    }

    private static WebApplication UseDevelopmentSpaHost(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
            return app;

        var spaDevelopmentServerUrl = app.Configuration["SpaDevelopmentServerUrl"];

        if (string.IsNullOrEmpty(spaDevelopmentServerUrl))
            return app;

        app.UseSpa(spa => spa.UseProxyToSpaDevelopmentServer(spaDevelopmentServerUrl));

        return app;
    }

    private static WebApplicationBuilder AddMediatR(this WebApplicationBuilder builder)
    {
        builder
           .Services
           .AddMediatR(config =>
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return builder;
    }

    private static WebApplicationBuilder AddLogging(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((_, configuration) => { configuration.ReadFrom.Configuration(builder.Configuration); });

        return builder;
    }

    private static WebApplicationBuilder AddControllers(this WebApplicationBuilder builder)
    {
        builder
           .Services
           .AddControllers();

        return builder;
    }

    private static WebApplicationBuilder AddMapper(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddSingleton(_ =>
        {
            var config = new TypeAdapterConfig();
            config.Default.PreserveReference(true);
            config.Scan(typeof(Startup).Assembly);

            return config;
        });

        services.AddSingleton<IMapper, ServiceMapper>();

        return builder;
    }

    private static WebApplicationBuilder AddMarten(this WebApplicationBuilder builder)
    {
        builder
           .Services
           .AddMarten(options =>
            {
                var connectionString = builder
                   .Configuration
                   .GetConnectionString("EventStore")!;

                options.Connection(connectionString);
                options.Logger();
                options.AutoCreateSchemaObjects = AutoCreate.All;
                options.DatabaseSchemaName = new NpgsqlConnectionStringBuilder(connectionString).Username!;
            })
           .ApplyAllDatabaseChangesOnStartup()
           .AssertDatabaseMatchesConfigurationOnStartup()
           .OptimizeArtifactWorkflow()
           .UseLightweightSessions();

        return builder;
    }
    private static WebApplicationBuilder AddHttpClient(this WebApplicationBuilder builder)
    {
        builder
           .Services
           .AddHttpClient();

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