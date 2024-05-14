using MapsterMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OnlySpans.PolyLeads.Api.Controllers.Abstractions;
using OnlySpans.PolyLeads.Api.Extensions;
using OnlySpans.PolyLeads.Api.Features.Documents.Create;
using OnlySpans.PolyLeads.Api.Features.Documents.Delete;
using OnlySpans.PolyLeads.Api.Features.Documents.Edit;
using OnlySpans.PolyLeads.Api.Features.Documents.GetDetailed;
using OnlySpans.PolyLeads.Api.Features.Documents.Query;

namespace OnlySpans.PolyLeads.Api.Controllers.V1;

using Dto = Dto.Data;

[Route("/api/v1/document")]
public sealed class DocumentController(IMediator mediator, IMapper mapper) :
    ApplicationController(mediator, mapper)
{
    [HttpGet]
    public async Task<IActionResult> Query(CancellationToken cancellationToken)
    {
        var query = new GetDocumentsQuery();
        var documents = await Mediator.Send(query, cancellationToken);
        return Ok(documents);
    }

    [HttpGet("{documentId:long}")]
    public async Task<IActionResult> GetDetailed(
        [FromRoute] long documentId,
        CancellationToken cancellationToken)
    {
        var query = new GetDetailedDocumentQuery(documentId);
        var detailedDocument = await Mediator.Send(query, cancellationToken);
        return Ok(detailedDocument);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] Dto.Document dto,
        CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();
        var command = Mapper.Map<CreateDocumentCommand>(dto) with {UserId = userId};
        var document = await Mediator.Send(command, cancellationToken);
        return StatusCode(StatusCodes.Status201Created, document);
    }

    [Authorize]
    [HttpPut("{documentId:long}")]
    public async Task<IActionResult> Edit(
        [FromRoute] long documentId,
        [FromBody] Dto.Document dto,
        CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();
        var command = new EditDocumentCommand(documentId, dto, userId);
        var document = await Mediator.Send(command, cancellationToken);
        return Ok(document);
    }

    [Authorize]
    [HttpDelete("{documentId:long}")]
    public async Task<IActionResult> Delete(
        [FromRoute] long documentId,
        CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();
        var command = new DeleteDocumentCommand(documentId, userId);
        await Mediator.Send(command, cancellationToken);
        return Ok();
    }
}
