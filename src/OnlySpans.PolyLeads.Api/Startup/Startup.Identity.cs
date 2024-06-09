using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using OnlySpans.PolyLeads.Api.Data.Options;
using OnlySpans.PolyLeads.Api.Utils;

namespace OnlySpans.PolyLeads.Api.Startup;

public static partial class Startup
{
    private static async Task<WebApplication> SeedUserRolesAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var provider = scope.ServiceProvider;

        var roleManager = provider.GetRequiredService<RoleManager<Entities.ApplicationUserRole>>();

        var roles = ApplicationRoleName
            .All
            .Select(x => new Entities.ApplicationUserRole { Name = x });

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role.Name!))
            {
                var result = await roleManager.CreateAsync(role);

                if (!result.Succeeded)
                    throw new Exception($"Ошибка при создании роли {role.Name}.");
            }
        }

        return app;
    }

    private static async Task<WebApplication> SeedMasterUserAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var provider = scope.ServiceProvider;

        var masterRoleOptions = provider
            .GetRequiredService<IOptions<MasterRoleOptions>>()
            .Value;

        var userManager = provider.GetRequiredService<UserManager<Entities.ApplicationUser>>();

        var masterUser = await userManager.FindByNameAsync(masterRoleOptions.UserName);

        if (masterUser is not null)
        {
            var hasRightPassword = await userManager.CheckPasswordAsync(masterUser, masterRoleOptions.Password);

            var hasAdminRole = await userManager.IsInRoleAsync(masterUser, masterRoleOptions.Role);

            if (hasRightPassword && hasAdminRole)
                return app;

            await userManager.DeleteAsync(masterUser);
        }

        masterUser = new Entities.ApplicationUser
        {
            FirstName = masterRoleOptions.FirstName,
            LastName = masterRoleOptions.LastName,
            UserName = masterRoleOptions.UserName
        };

        await userManager.CreateAsync(masterUser, masterRoleOptions.Password);

        await userManager.AddToRoleAsync(masterUser, masterRoleOptions.Role);
        
        return app;
    }
}