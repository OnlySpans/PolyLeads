using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using OnlySpans.PolyLeads.Api.Exceptions;
using OnlySpans.PolyLeads.Dto.Roles;

namespace OnlySpans.PolyLeads.Api.Features.RoleManagement.GetUserInfo;

public sealed record GetUserInfoCommand(string UserId)
    : IRequest<User?>;

[UsedImplicitly]
public sealed class GetUserInfoCommandHandler :
    IRequestHandler<GetUserInfoCommand, User?>
{
    private readonly UserManager<Entities.ApplicationUser> _userManager;

    public GetUserInfoCommandHandler(
        UserManager<Entities.ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<User?> Handle(
        GetUserInfoCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);

        ResourceNotFoundException.ThrowIfNull(
            user,
            $"Пользователь с id {request.UserId} не найден");

        var roles = await _userManager.GetRolesAsync(user);

        var userInfo = new User
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            UserName = user.UserName ?? "",
            Role = roles.FirstOrDefault() ?? ""
        };

        return userInfo;
    }
}
