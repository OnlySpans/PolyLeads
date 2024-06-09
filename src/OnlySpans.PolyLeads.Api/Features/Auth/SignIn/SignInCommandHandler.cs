using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using OnlySpans.PolyLeads.Api.Data.Entities;
using OnlySpans.PolyLeads.Api.Exceptions;

namespace OnlySpans.PolyLeads.Api.Features.Auth.SignIn;

public sealed record SignInCommand : IRequest
{
    public string UserName { get; init; } = string.Empty;

    public string Password { get; init; } = string.Empty;
}

[UsedImplicitly]
public sealed class SignInCommandHandler :
    IRequestHandler<SignInCommand>
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    public SignInCommandHandler(SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public async ValueTask<Unit> Handle(
        SignInCommand request,
        CancellationToken cancellationToken)
    {
        var username = request.UserName;

        var result = await _signInManager
           .PasswordSignInAsync(
                username,
                request.Password,
                isPersistent: true,
                lockoutOnFailure: false);

        if (!result.Succeeded)
            throw new AuthenticationException("Неправильный логин или пароль");

        return Unit.Value;
    }
}