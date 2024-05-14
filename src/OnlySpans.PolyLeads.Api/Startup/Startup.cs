namespace OnlySpans.PolyLeads.Api.Startup;

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
           .AddSwagger()
           .AddServiceDefaults()
           .AddApplicationDbContext()
           .AddIdentity()
           .AddDocumentRecognition()
           .AddControllers();

        return Task.FromResult(builder);
    }

    public static async Task<WebApplication> Configure(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseRouting();

        app.UseDevelopmentConfiguration();
        app.MapControllers();

        await app.MigrateDatabaseAsync();

        return app;
    }
}
