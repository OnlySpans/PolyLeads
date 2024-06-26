using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using OnlySpans.PolyLeads.Api.Data.Options;
using OnlySpans.PolyLeads.Api.Exceptions;
using OnlySpans.PolyLeads.Api.Features.Seeding;

namespace OnlySpans.PolyLeads.Api.Startup;

public partial class Startup
{
    private static async Task<WebApplication> SeedDocumentsAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var provider = scope.ServiceProvider;

        var sender = provider
           .GetRequiredService<ISender>();

        var masterRoleOptions = provider
           .GetRequiredService<IOptions<MasterRoleOptions>>()
           .Value;

        var userManager = provider
           .GetRequiredService<UserManager<Entities.ApplicationUser>>();

        var masterUser = await userManager
           .FindByNameAsync(masterRoleOptions.UserName);

        if (masterUser == null)
        {
            throw new ResourceNotFoundException("Пользователя с правами администратора нет");
        }

        var command = new DocumentSeedCommand
        {
            FilePath = "Resources/documents-seed.json",
            Id = masterUser.Id
        };

        await sender.Send(command);

        return app;
    }
}