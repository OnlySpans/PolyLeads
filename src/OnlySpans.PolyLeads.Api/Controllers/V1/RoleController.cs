using System.Security.Claims;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlySpans.PolyLeads.Api.Controllers.Abstractions;
using OnlySpans.PolyLeads.Api.Features.RoleManagement.GetUserInfo;
using OnlySpans.PolyLeads.Api.Features.RoleManagement.GrantRole;
using OnlySpans.PolyLeads.Api.Utils;
using OnlySpans.PolyLeads.Dto.Roles;

namespace OnlySpans.PolyLeads.Api.Controllers.V1;

[Route("api/v1/role")]
public sealed class RoleController(IMediator mediator, IMapper mapper) :
    ApplicationController(mediator, mapper)
{
    [Authorize(Roles = ApplicationRoleName.Admin)]
    [HttpPost("grant")]
    public async Task<IActionResult> GrantRoleToUser(
        [FromBody] GrantRoleInput input,
        CancellationToken cancellationToken)
    {
        var command = Mapper.Map<GrantRoleCommand>(input);
        await Mediator.Send(command, cancellationToken);
        return Ok();
    }

    [Authorize]
    [HttpGet("current-user")]
    public async Task<IActionResult> GetCurrentUserInfo(
        CancellationToken cancellationToken)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId is null)
            return NoContent();

        var command = new GetUserInfoCommand(userId);
        var user = await Mediator.Send(command, cancellationToken);
        return Ok(user);
    }
}
