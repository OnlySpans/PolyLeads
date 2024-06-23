using OnlySpans.PolyLeads.Api.Features.Seeding;

namespace OnlySpans.PolyLeads.Api.Startup;

public partial class Startup
{
    private static async Task<WebApplication> SeedDocumentsAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var provider = scope.ServiceProvider;

        var sender = provider.GetRequiredService<ISender>();

        var command = new DocumentSeedCommand();

        await sender.Send(command);

        return app;
    }
}