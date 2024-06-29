using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using OnlySpans.PolyLeads.Api.Data.Options;
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

        if (masterUser is null)
        {
            throw new UnreachableException("Пользователь с правами администратора не добавлен");
        }

        var filePath = "Resources/documents-seed.json";

        var userId = masterUser.Id;

        var command = new SeedDocumentCommand(filePath, userId);

        await sender.Send(command);

        return app;
    }
}