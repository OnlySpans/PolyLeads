using JetBrains.Annotations;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        var user = await SignInManager
           .UserManager
           .Users
           .Where(x => x.UserName == input.Key || x.Email == input.Key)
           .FirstOrDefaultAsync(cancellationToken);

        if (user is null || user.UserName is null)
            throw new AuthorizationException("User not found");

        var userName = user.UserName;
        
        var result = await SignInManager
           .PasswordSignInAsync(
                userName,
                input.Password,
                true,
                false);

        if (!result.Succeeded)
            throw new AuthorizationException("Failed to login");

        return Mapper
           .Map<Schema.ApplicationUser>(user);
    }
}