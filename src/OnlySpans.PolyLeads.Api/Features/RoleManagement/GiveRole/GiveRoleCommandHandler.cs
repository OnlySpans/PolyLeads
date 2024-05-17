using Hangfire.Annotations;
using Microsoft.AspNetCore.Identity;
using OnlySpans.PolyLeads.Api.Exceptions;

namespace OnlySpans.PolyLeads.Api.Features.RoleManagement.GiveRole;

public sealed record GiveRoleCommand : IRequest
{
    public string UserName { get; init; } = string.Empty;

    public string RoleName { get; init; } = string.Empty;
}

[UsedImplicitly]
public sealed class GiveRoleCommandHandler :
    IRequestHandler<GiveRoleCommand>
{
    private UserManager<Entities.ApplicationUser> UserManager { get; init; }
    
    public GiveRoleCommandHandler(
        UserManager<Entities.ApplicationUser> userManager)
    {
        UserManager = userManager;
    }

    public async Task Handle(
        GiveRoleCommand request,
        CancellationToken cancellationToken)
    {
        var user = await UserManager.FindByNameAsync(request.UserName);

        ResourceNotFoundException.ThrowIfNull(
            user, 
            $"пользователь с ником {request.UserName} не найден");
        
        await UserManager.AddToRoleAsync(user, request.RoleName);
        
        var userRoles = await UserManager.GetRolesAsync(user);
        
        if (!userRoles.Contains(request.RoleName))
            throw new RoleManagementException(
                $"не получилось присвоить пользователю с ником {request.UserName} роль {request.RoleName}");
    }
}