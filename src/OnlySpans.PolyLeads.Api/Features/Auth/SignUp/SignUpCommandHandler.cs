using JetBrains.Annotations;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using OnlySpans.PolyLeads.Api.Data.Entities;
using OnlySpans.PolyLeads.Api.Exceptions;
using OnlySpans.PolyLeads.Api.Features.Auth.SignIn;
using OnlySpans.PolyLeads.Api.Utils;

namespace OnlySpans.PolyLeads.Api.Features.Auth.SignUp;

public sealed record SignUpCommand : IRequest
{
    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public string UserName { get; init; } = string.Empty;

    public string Password { get; init; } = string.Empty;
}

[UsedImplicitly]
public sealed class SignUpCommandHandler :
    IRequestHandler<SignUpCommand>
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;
    private readonly UserManager<ApplicationUser> _userManager;

    public SignUpCommandHandler(
        IMapper mapper,
        ISender sender,
        UserManager<ApplicationUser> userManager)
    {
        _mapper = mapper;
        _sender = sender;
        _userManager = userManager;
    }

    public async ValueTask<Unit> Handle(
        SignUpCommand request,
        CancellationToken cancellationToken)
    {
        var user = _mapper
           .Map<ApplicationUser>(request);

        var result = await _userManager
           .CreateAsync(user, request.Password);

        if (!result.Succeeded)
            throw new AuthenticationException(string.Join("; ",
                result
                   .Errors
                   .Select(x => x.Description)));

        result = await _userManager
            .AddToRoleAsync(user, ApplicationRoleName.Student);

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

        await _sender
           .Send(
                command,
                cancellationToken);
        
        return Unit.Value;
    }
}
