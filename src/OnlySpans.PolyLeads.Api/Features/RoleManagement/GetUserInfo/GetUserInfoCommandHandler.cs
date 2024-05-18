using Hangfire.Annotations;
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
    private UserManager<Entities.ApplicationUser> UserManager { get; init; }

    public GetUserInfoCommandHandler(
        UserManager<Entities.ApplicationUser> userManager)
    {
        UserManager = userManager;
    }

    public async Task<User?> Handle(
        GetUserInfoCommand request,
        CancellationToken cancellationToken)
    {
        var user = await UserManager.FindByIdAsync(request.UserId);

        ResourceNotFoundException.ThrowIfNull(
            user, 
            $"Пользователь с id {request.UserId} не найден");

        var roles = await UserManager.GetRolesAsync(user);

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