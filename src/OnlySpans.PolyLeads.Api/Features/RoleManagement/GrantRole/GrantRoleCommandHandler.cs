using Hangfire.Annotations;
using Microsoft.AspNetCore.Identity;
using OnlySpans.PolyLeads.Api.Exceptions;
using OnlySpans.PolyLeads.Api.Utils;

namespace OnlySpans.PolyLeads.Api.Features.RoleManagement.GrantRole;

public sealed record GrantRoleCommand : IRequest
{
    public string UserName { get; init; } = string.Empty;

    public string RoleName { get; init; } = string.Empty;
}

[UsedImplicitly]
public sealed class GrantRoleCommandHandler :
    IRequestHandler<GrantRoleCommand>
{
    private UserManager<Entities.ApplicationUser> UserManager { get; init; }
    
    public GrantRoleCommandHandler(
        UserManager<Entities.ApplicationUser> userManager)
    {
        UserManager = userManager;
    }

    public async Task Handle(
        GrantRoleCommand request,
        CancellationToken cancellationToken)
    {
        var user = await UserManager.FindByNameAsync(request.UserName);

        ResourceNotFoundException.ThrowIfNull(
            user, 
            $"Пользователь с именем {request.UserName} не найден");

        if (await UserManager.IsInRoleAsync(user, request.RoleName))
            return;

        if (!ApplicationRoleName.All.Contains(request.RoleName))
            throw new RoleManagementException($"Роли с названием {request.RoleName} не существует");

        var userRoles = await UserManager.GetRolesAsync(user);

        await UserManager.RemoveFromRolesAsync(user, userRoles);

        var result = await UserManager.AddToRoleAsync(user, request.RoleName);

        if (!result.Succeeded)
            throw new RoleManagementException(
                $"Не получилось присвоить пользователю с именем {request.UserName} роль {request.RoleName}");
    }
}