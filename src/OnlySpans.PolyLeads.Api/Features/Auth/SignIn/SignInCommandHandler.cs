using JetBrains.Annotations;
using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlySpans.PolyLeads.Api.Data.Entities;
using OnlySpans.PolyLeads.Api.Exceptions;
using OnlySpans.PolyLeads.Dto.Data;

namespace OnlySpans.PolyLeads.Api.Features.Auth.SignIn;

public sealed record SignInCommand(SignInInput Input) :
    IRequest;

[UsedImplicitly]
public sealed class SignInCommandHandler :
    IRequestHandler<SignInCommand>
{
    private SignInManager<ApplicationUser> SignInManager { get; init; }

    public SignInCommandHandler(SignInManager<ApplicationUser> signInManager)
    {
        SignInManager = signInManager;
    }

    public async Task Handle(
        SignInCommand request,
        CancellationToken cancellationToken)
    {
        var input = request.Input;

        var username = input.UserName;

        var result = await SignInManager
           .PasswordSignInAsync(
                username,
                input.Password,
                isPersistent: true,
                lockoutOnFailure: false);

        if (!result.Succeeded)
            throw new AuthenticationException("Неправильный логин или пароль");
    }
}