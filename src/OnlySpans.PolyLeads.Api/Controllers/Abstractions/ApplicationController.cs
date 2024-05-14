using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace OnlySpans.PolyLeads.Api.Controllers.Abstractions;

[ApiController]
public abstract class ApplicationController(IMediator mediator, IMapper mapper) : ControllerBase
{
    protected IMediator Mediator { get; init; } = mediator;

    protected IMapper Mapper { get; init; } = mapper;
}
