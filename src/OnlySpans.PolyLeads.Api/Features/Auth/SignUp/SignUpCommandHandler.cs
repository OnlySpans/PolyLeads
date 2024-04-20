using JetBrains.Annotations;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlySpans.PolyLeads.Api.Data.Entities;
using OnlySpans.PolyLeads.Api.Exceptions;
using OnlySpans.PolyLeads.Dto.Data;

namespace OnlySpans.PolyLeads.Api.Features.Auth.SignUp;

public sealed record SignUpCommand(SignUpInput Input) :
    IRequest;

[UsedImplicitly]
public sealed class SignUpCommandHandler :
    IRequestHandler<SignUpCommand>
{
    private IMapper Mapper { get; init; }
    private UserManager<ApplicationUser> UserManager { get; init; }

    public SignUpCommandHandler(
        UserManager<ApplicationUser> userManager,
        IMapper mapper)
    {
        UserManager = userManager;
        Mapper = mapper;
    }

    public async Task Handle(
        SignUpCommand request,
        CancellationToken cancellationToken)
    {
        var input = request.Input;

        var user = Mapper
           .Map<ApplicationUser>(input);

        var result = await UserManager
           .CreateAsync(user, input.Password);

        if (!result.Succeeded)
            throw new AuthenticationException(string.Join("; ",
                result
                   .Errors
                   .Select(x => x.Description)));
    }
}