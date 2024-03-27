using JetBrains.Annotations;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlySpans.PolyLeads.Api.Data.Entities;
using OnlySpans.PolyLeads.Api.Exceptions;
using OnlySpans.PolyLeads.Api.Schema.Inputs.Auth;

namespace OnlySpans.PolyLeads.Api.Features.Auth.SignUp;

using Schema = Schema.Payloads.Auth;

public sealed record SignUpCommand(SignUpInput Input) :
    IRequest<Schema.ApplicationUser>;

[UsedImplicitly]
public sealed class SignUpCommandHandler :
    IRequestHandler<SignUpCommand, Schema.ApplicationUser>
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

    public async Task<Schema.ApplicationUser> Handle(
        SignUpCommand request,
        CancellationToken cancellationToken)
    {
        var input = request.Input;

        var user = new ApplicationUser
        {
            FirstName = input.FirstName,
            LastName = input.LastName,
            Patronymic = input.Patronymic,
            UserName = input.UserName,
            Email = input.Email
        };

        var result = await UserManager
           .CreateAsync(user, input.Password);

        if (!result.Succeeded)
            throw new AuthenticationException(string.Join("; ",
                result
                   .Errors
                   .Select(x => x.Description)
            ));

        return Mapper
           .Map<Schema.ApplicationUser>(user);
    }
}