using JetBrains.Annotations;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using OnlySpans.PolyLeads.Api.Data.Entities;
using OnlySpans.PolyLeads.Api.Exceptions;
using OnlySpans.PolyLeads.Api.Features.Auth.SignIn;

namespace OnlySpans.PolyLeads.Api.Features.Auth.SignUp;

public sealed record SignUpCommand : IRequest
{
    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public string UserName { get; init; } = string.Empty;

    public string Password { get; init; } = String.Empty;
}

[UsedImplicitly]
public sealed class SignUpCommandHandler :
    IRequestHandler<SignUpCommand>
{
    private IMapper Mapper { get; init; }
    private UserManager<ApplicationUser> UserManager { get; init; }

    private ISender Sender { get; init; }

    public SignUpCommandHandler(
        UserManager<ApplicationUser> userManager,
        IMapper mapper,
        ISender sender)
    {
        UserManager = userManager;
        Mapper = mapper;
        Sender = sender;
    }

    public async Task Handle(
        SignUpCommand request,
        CancellationToken cancellationToken)
    {
        var user = Mapper
           .Map<ApplicationUser>(request);

        var result = await UserManager
           .CreateAsync(user, request.Password);

        if (!result.Succeeded)
            throw new AuthenticationException(string.Join("; ",
                result
                   .Errors
                   .Select(x => x.Description)));

        result = await UserManager
            .AddToRoleAsync(user, "Student");

        if (!result.Succeeded)
            throw new RoleManagementException(string.Join("; ",
                result
                    .Errors
                    .Select(x => x.Description)));

        var command = new SignInCommand
        {
            UserName = request.UserName,
            Password = request.Password
        };

        await Sender
           .Send(
                command,
                cancellationToken);
    }
}