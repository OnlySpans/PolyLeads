using Hangfire;
using Hangfire.PostgreSql;
using HangfireBasicAuthenticationFilter;
using Microsoft.Extensions.Options;
using Npgsql;
using OnlySpans.PolyLeads.Api.Data.Options;
using OnlySpans.PolyLeads.Api.Workers;

namespace OnlySpans.PolyLeads.Api.Startup;

public static partial class Startup
{
    private static WebApplication UseSchedulerDashboard(this WebApplication app)
    {
        var options = app
           .Services
           .GetRequiredService<IOptions<SchedulerDashboardOptions>>()
           .Value;

        if (!options.Enabled)
            return app;

        app.UseHangfireDashboard("/api/hangfire", new()
        {
            Authorization =
            [
                new HangfireCustomBasicAuthenticationFilter
                {
                    User = options.Login,
                    Pass = options.Password
                }
            ]
        });

        return app;
    }

    private static WebApplicationBuilder AddWorkers(this WebApplicationBuilder builder)
    {
        builder
           .Services
           .AddHostedService<RecognitionWorkerRunner>();

        return builder;
    }

    private static WebApplicationBuilder AddScheduler(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        var connectionString = builder
           .Configuration
           .GetConnectionString("Scheduler");

        var schemaName = new NpgsqlConnectionStringBuilder(connectionString).Username!;

        services
           .AddHangfire(config => config
               .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
               .UseSimpleAssemblyNameTypeSerializer()
               .UseRecommendedSerializerSettings()
               .UsePostgreSqlStorage(connectionString, new()
                {
                    SchemaName = schemaName
                }));

        services
           .AddHangfireServer();

        return builder;
    }
}
