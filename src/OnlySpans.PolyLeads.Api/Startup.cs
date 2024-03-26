using System.Reflection;
using HotChocolate.Data;
using Mapster;
using MapsterMapper;
using Marten;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql;
using OnlySpans.PolyLeads.Api.Data.Contexts;
using OnlySpans.PolyLeads.Api.Abstractions.Recognition;
using OnlySpans.PolyLeads.Api.Data.Entities;
using OnlySpans.PolyLeads.Api.Services.Logging;
using OnlySpans.PolyLeads.Api.Services.Recognition;
using Serilog;
using Weasel.Core;

namespace OnlySpans.PolyLeads.Api;

public static class Startup
{
    public static Task<WebApplicationBuilder> ConfigureServices(this WebApplicationBuilder builder)
    {
        builder
           .AddAuth()
           .AddMediatR()
           .AddMarten()
           .AddLogging()
           .AddMapper()
           .AddGraphQL()
           .AddServiceDefaults()
           .AddApplicationDbContext()
           .AddIdentity()
           .AddDocumentRecognition();

        return Task.FromResult(builder);
    }

    public static async Task<WebApplication> Configure(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseRouting();

        app.MapGraphQL("/api/graphql");

        await app.MigrateDatabaseAsync();

        return app;
    }

    #region WebApplicationBuilder | Use.*

    private static async Task MigrateDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var provider = scope.ServiceProvider;

        await using var dbContext = provider.GetRequiredService<ApplicationDbContext>();

        if (!dbContext.Database.IsRelational()) return;

        await dbContext.Database.MigrateAsync();
    }

    #endregion

    #region WebApplicationBuilder | Add.*

    private static WebApplicationBuilder AddApplicationDbContext(this WebApplicationBuilder builder)
    {
        builder
           .Services
           .AddDbContextPool<ApplicationDbContext>(options =>
            {
                var connectionString = builder
                   .Configuration
                   .GetConnectionString("ApplicationDbContext")!;

                var connectionStringBuilder = new NpgsqlConnectionStringBuilder(connectionString);
                var username = connectionStringBuilder.Username;

                options.UseNpgsql(connectionString, o =>
                {
                    if (username is null)
                        return;

                    o.MigrationsHistoryTable(HistoryRepository.DefaultTableName, username);
                });
            });

        return builder;
    }

    private static WebApplicationBuilder AddMediatR(this WebApplicationBuilder builder)
    {
        builder
           .Services
           .AddMediatR(config =>
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return builder;
    }

    private static WebApplicationBuilder AddGraphQL(this WebApplicationBuilder builder)
    {
        builder
           .Services
           .AddGraphQLServer()
            .AddErrorFilter<GenericErrorFilter>()
            //.AddFluentValidation()
           .AddMartenFiltering()
           .AddMartenSorting()
           .AddProjections()
           .AddFiltering()
           .AddQueryableCursorPagingProvider()
           .SetPagingOptions(new()
            {
                IncludeTotalCount = true
            })
           .AddInMemorySubscriptions()
           .AddQueryType()
           .AddMutationType()
           .AddApiTypes();

        return builder;
    }

    private static WebApplicationBuilder AddLogging(this WebApplicationBuilder builder)
    {
        builder
           .Host
           .UseSerilog((_, configuration) =>
                    configuration.ReadFrom.Configuration(builder.Configuration),
                writeToProviders: true);

        builder
           .Services
           .AddSingleton<IMartenLogger, DefaultMartenLogger>();

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
           .AddMarten(provider =>
            {
                var options = new StoreOptions();

                var connectionString = builder
                   .Configuration
                   .GetConnectionString("DocumentStore")!;

                options.Connection(connectionString);
                options.Logger(provider.GetRequiredService<IMartenLogger>());
                options.AutoCreateSchemaObjects = AutoCreate.All;

                return options;
            })
           .ApplyAllDatabaseChangesOnStartup()
           .AssertDatabaseMatchesConfigurationOnStartup()
           .OptimizeArtifactWorkflow()
           .UseLightweightSessions();

        return builder;
    }

    private static WebApplicationBuilder AddDocumentRecognition(this WebApplicationBuilder builder)
    {
        builder
           .Services
           .AddScoped<IDocumentRecognition, SearchablePdfRecognition>();

        return builder;
    }

    private static WebApplicationBuilder AddAuth(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services
           .AddAuthentication();

        services
           .AddAuthorization();

        return builder;
    }

    private static WebApplicationBuilder AddIdentity(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services
           .AddIdentity<ApplicationUser, ApplicationUserRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            })
           .AddEntityFrameworkStores<ApplicationDbContext>();

        services.ConfigureApplicationCookie(options =>
        {
            options.Events.OnRedirectToLogin = context =>
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                return Task.CompletedTask;
            };

            options.Events.OnRedirectToAccessDenied = context =>
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                return Task.CompletedTask;
            };
        });

        return builder;
    }

    #endregion

    #region WebApplicationBuilder | public deps

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

[QueryType]
public sealed class Query
{
    public string NewQuery() => "ass";
}