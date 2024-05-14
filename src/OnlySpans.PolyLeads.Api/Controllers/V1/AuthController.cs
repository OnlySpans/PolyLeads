using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

using OnlySpans.PolyLeads.Api.Controllers.Abstractions;
using OnlySpans.PolyLeads.Api.Features.Auth.SignIn;
using OnlySpans.PolyLeads.Api.Features.Auth.SignUp;
using OnlySpans.PolyLeads.Dto.Data;

namespace OnlySpans.PolyLeads.Api.Controllers.V1;

[Route("api/v1/auth")]
public sealed class AuthController(IMediator mediator, IMapper mapper) :
    ApplicationController(mediator, mapper)
{
    [HttpPost("signin")]
    public async Task<IActionResult> SignIn(
        [FromBody] SignInInput input,
        CancellationToken cancellationToken)
    {
        var command = Mapper.Map<SignInCommand>(input);
        await Mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp(
        [FromBody] SignUpInput input,
        CancellationToken cancellationToken)
    {
        var command = Mapper.Map<SignUpCommand>(input);
        await Mediator.Send(command, cancellationToken);
        return Ok();
    }
}
