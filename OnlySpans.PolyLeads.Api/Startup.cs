﻿using System.Reflection;
using HotChocolate.Data;
using Mapster;
using MapsterMapper;
using Marten;
using Npgsql;
using OnlySpans.PolyLeads.Api.Abstractions.Recognition;
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
           .AddMediatR()
           .AddMarten()
           .AddLogging()
           .AddMapper()
           .AddGraphQL()
           .AddDocumentRecognition();

        return Task.FromResult(builder);
    }

    public static async Task<WebApplication> Configure(this WebApplication app)
    {
        app.UseExceptionHandler();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();
        app.MapGraphQL("api/graphql");

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

    private static WebApplicationBuilder AddGraphQL(this WebApplicationBuilder builder)
    {
        builder
           .Services
           .AddGraphQLServer()
            //.AddErrorFilter<GenericErrorFilter>()
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
           .AddMutationConventions()
           .AddQueryType()
           .AddMutationType();
        //.AddApiTypes();

        return builder;
    }

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
                options.DatabaseSchemaName = new NpgsqlConnectionStringBuilder(connectionString).Username!;

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
