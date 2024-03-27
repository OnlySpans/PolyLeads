using JetBrains.Annotations;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlySpans.PolyLeads.Api.Data.Contexts;
using OnlySpans.PolyLeads.Api.Data.Entities;
using OnlySpans.PolyLeads.Api.Exceptions;
using OnlySpans.PolyLeads.Api.Schema.Inputs.Auth;

namespace OnlySpans.PolyLeads.Api.Features.Auth.SignIn;

using Schema = Schema.Payloads.Auth;

public sealed record SignInCommand(SignInInput Input) :
    IRequest<Schema.ApplicationUser>;

[UsedImplicitly]
public sealed class SignInCommandHandler :
    IRequestHandler<SignInCommand, Schema.ApplicationUser>
{
    private ApplicationDbContext Context { get; init; }

    private IMapper Mapper { get; init; }

    private SignInManager<ApplicationUser> SignInManager { get; init; }

    public SignInCommandHandler(
        SignInManager<ApplicationUser> signInManager,
        ApplicationDbContext context,
        IMapper mapper)
    {
        SignInManager = signInManager;
        Context = context;
        Mapper = mapper;
    }

    public async Task<Schema.ApplicationUser> Handle(
        SignInCommand request,
        CancellationToken cancellationToken)
    {
        var input = request.Input;

        if (input.Key is UserName userName)
        {
            var result = await SignInManager
               .PasswordSignInAsync(
                    userName.UserNameValue,
                    input.Password,
                    true,
                    false);

            if (!result.Succeeded)
            {
                throw new AuthorizationException("Authorization error");
            }

            return Mapper
               .Map<Schema.ApplicationUser>(
                    Context
                       .Users
                       .First(x => x.UserName == userName.UserNameValue));
        }

        else
        {
            var email = (Email) input.Key;

            var user = Context
               .Users
               .First(x => x.Email == email.EmailValue);

            var result = await SignInManager
               .PasswordSignInAsync(
                    user,
                    input.Password,
                    true,
                    false);

            if (!result.Succeeded)
            {
                throw new AuthorizationException("Authorization error");
            }

            return Mapper
               .Map<Schema.ApplicationUser>(user);
        }
    }
}