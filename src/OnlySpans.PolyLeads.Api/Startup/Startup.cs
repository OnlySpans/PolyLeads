﻿using OnlySpans.PolyLeads.Api.Extensions;

namespace OnlySpans.PolyLeads.Api.Startup;

public static partial class Startup
{
    public static Task<WebApplicationBuilder> ConfigureServices(this WebApplicationBuilder builder)
    {
        builder
           .AddAuth()
           .AddOptions()
           .AddHttpClient()
           .AddScheduler()
           .AddWorkers()
           .AddMediatR()
           .AddMarten()
           .AddLogging()
           .AddMapper()
           .AddSwagger()
           .AddApplicationDbContext()
           .AddIdentity()
           .AddDocumentRecognition()
           .AddControllers();

        return Task.FromResult(builder);
    }

    public static async Task<WebApplication> Configure(this WebApplication app)
    {
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseDevelopmentConfiguration();
        app.MapControllers();

        app.UseSchedulerDashboard();

        await app.MigrateDatabaseAsync();
        app.SeedUserRoles();

        return app;
    }
}
