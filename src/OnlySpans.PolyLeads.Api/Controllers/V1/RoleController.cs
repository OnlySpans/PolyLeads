using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlySpans.PolyLeads.Api.Controllers.Abstractions;
using OnlySpans.PolyLeads.Api.Features.RoleManagement.GrantRole;
using OnlySpans.PolyLeads.Dto.Data;

namespace OnlySpans.PolyLeads.Api.Controllers.V1;

[Route("api/v1/role")]
[Authorize(Roles = "Admin")]
public sealed class RoleController(IMediator mediator, IMapper mapper) :
    ApplicationController(mediator, mapper)
{
    [HttpPost("grant")]
    public async Task<IActionResult> GrantRoleToUser(
        [FromBody] GrantRoleInput input,
        CancellationToken cancellationToken)
    {
        var command = Mapper.Map<GrantRoleCommand>(input);
        await Mediator.Send(command, cancellationToken);
        return Ok();
    }
}
