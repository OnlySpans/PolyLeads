using JetBrains.Annotations;
using MediatR;
using OnlySpans.PolyLeads.Api.Features.Auth.SignUp;
using OnlySpans.PolyLeads.Api.Schema.Inputs.Auth;

namespace OnlySpans.PolyLeads.Api.Features.Auth;

using Schema = Schema.Payloads.Auth;

[PublicAPI]
[MutationType]
public sealed class AuthMutationRoot
{
    [PublicAPI]
    public async Task<Schema.ApplicationUser> SignUp(
        SignUpInput input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var command = new SignUpCommand(input);
        var user = await mediator.Send(command, cancellationToken);
        return user;
    }
}