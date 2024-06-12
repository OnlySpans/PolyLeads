using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using OnlySpans.PolyLeads.Api.Data.Abstractions.Commands;
using OnlySpans.PolyLeads.Api.Data.Records;
using OnlySpans.PolyLeads.Api.Exceptions;
using OnlySpans.PolyLeads.Api.Extensions;
using OnlySpans.PolyLeads.Dto.Roles;

namespace OnlySpans.PolyLeads.Api.Features.RoleManagement.GetUserInfo;

public sealed record GetUserInfoCommand :
    IRequest<User?>,
    ICalledByUser
{
    public MaybeSet<Identity?> User { get; set; }
}

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

    public async ValueTask<User?> Handle(
        GetUserInfoCommand request,
        CancellationToken cancellationToken)
    {
        var userId = request.GetUser().Id;
        var user = await _userManager.FindByIdAsync(userId.ToString());

        ResourceNotFoundException.ThrowIfNull(
            user,
            $"Пользователь с id {userId} не найден");

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
