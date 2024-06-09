using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace OnlySpans.PolyLeads.Api.Controllers.Abstractions;

[ApiController]
public abstract class ApplicationController(IMediator mediator, IMapper mapper) : ControllerBase
{
    protected IMediator Mediator { get; } = mediator;

    protected IMapper Mapper { get; } = mapper;

    protected IActionResult Created<TPayload>(TPayload payload) =>
        StatusCode(StatusCodes.Status201Created, payload);
}
