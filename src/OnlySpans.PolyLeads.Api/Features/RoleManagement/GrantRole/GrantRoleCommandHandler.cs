using JetBrains.Annotations;
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
    private readonly UserManager<Entities.ApplicationUser> _userManager;

    public GrantRoleCommandHandler(
        UserManager<Entities.ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async ValueTask<Unit> Handle(
        GrantRoleCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.UserName);

        ResourceNotFoundException.ThrowIfNull(
            user,
            $"Пользователь с именем {request.UserName} не найден");

        if (await _userManager.IsInRoleAsync(user, request.RoleName))
            return Unit.Value;

        if (!ApplicationRoleName.All.Contains(request.RoleName))
            throw new RoleManagementException($"Роли с названием {request.RoleName} не существует");

        var userRoles = await _userManager.GetRolesAsync(user);

        await _userManager.RemoveFromRolesAsync(user, userRoles);

        var result = await _userManager.AddToRoleAsync(user, request.RoleName);

        if (!result.Succeeded)
            throw new RoleManagementException(
                $"Не получилось присвоить пользователю с именем {request.UserName} роль {request.RoleName}");

        return Unit.Value;
    }
}