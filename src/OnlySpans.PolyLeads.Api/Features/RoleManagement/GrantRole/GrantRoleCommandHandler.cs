using Hangfire.Annotations;
using Microsoft.AspNetCore.Identity;
using OnlySpans.PolyLeads.Api.Exceptions;

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
        
        await UserManager.AddToRoleAsync(user, request.RoleName);
        
        var userRoles = await UserManager.GetRolesAsync(user);
        
        if (!userRoles.Contains(request.RoleName))
            throw new RoleManagementException(
                $"Не получилось присвоить пользователю с именем {request.UserName} роль {request.RoleName}");
    }
}