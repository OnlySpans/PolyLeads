using Marten;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql;
using OnlySpans.PolyLeads.Api.Data.Contexts;
using Weasel.Core;
using StoreOptions = Marten.StoreOptions;

namespace OnlySpans.PolyLeads.Api.Startup;

public static partial class Startup
{
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

                // Otherwise Schema Objects will be created in `public` schema
                options.DatabaseSchemaName = new NpgsqlConnectionStringBuilder(connectionString).Username!;
                options.AutoCreateSchemaObjects = AutoCreate.All;

                options
                   .Schema
                   .For<Entities.RecognitionResult>()
                   .FullTextIndex("russian", x => x.Content)
                   .NgramIndex(x => x.Content);

                return options;
            })
           .ApplyAllDatabaseChangesOnStartup()
           .AssertDatabaseMatchesConfigurationOnStartup()
           .OptimizeArtifactWorkflow()
           .UseLightweightSessions();

        return builder;
    }

    private static WebApplicationBuilder AddApplicationDbContext(this WebApplicationBuilder builder)
    {
        var connectionString = builder
           .Configuration
           .GetConnectionString("ApplicationDbContext")!;

        var connectionStringBuilder = new NpgsqlConnectionStringBuilder(connectionString);
        var username = connectionStringBuilder.Username;

        var isDevelopment = builder
           .Environment
           .IsDevelopment();

        builder
           .Services
           .AddDbContextPool<ApplicationDbContext>(options =>
            {
                options
                   .EnableSensitiveDataLogging(isDevelopment)
                   .EnableDetailedErrors(isDevelopment)
                   .UseNpgsql(
                    connectionString,
                    o => o.MigrationsHistoryTable(
                        HistoryRepository.DefaultTableName,
                        username));
            });

        return builder;
    }

    private static async Task MigrateDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var provider = scope.ServiceProvider;

        await using var dbContext = provider.GetRequiredService<ApplicationDbContext>();

        if (!dbContext.Database.IsRelational()) return;

        await dbContext.Database.MigrateAsync();
    }
    
    private static WebApplication SeedUserRoles(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var provider = scope.ServiceProvider;

        var roleManager = provider.GetRequiredService<RoleManager<Entities.ApplicationUserRole>>();
        
        var roles = new List<Entities.ApplicationUserRole>
        {
            new() { Name = "Admin" },
            new() { Name = "Trade_union" },
            new() { Name = "Headman" },
            new() { Name = "Student" }
        };
        
        foreach (var role in roles)
        {
            if (!roleManager.RoleExistsAsync(role.Name!).Result)
            {
                var result = roleManager.CreateAsync(role).Result;
                
                if (!result.Succeeded)
                    throw new Exception($"Ошибка при создании роли {role.Name}.");
            }
        }

        return app;
    }
}
