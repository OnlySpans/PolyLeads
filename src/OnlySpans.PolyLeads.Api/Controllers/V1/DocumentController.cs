using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlySpans.PolyLeads.Api.Features.Documents;

namespace OnlySpans.PolyLeads.Api.Controllers.V1;

using Dto = Dto.Data;

[Route("/api/v1/document")]
public sealed class DocumentController : ControllerBase
{
    public DocumentController(IMediator mediator)
    {
        Mediator = mediator;
    }

    private IMediator Mediator { get; init; }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] Dto.Document dto,
        CancellationToken cancellationToken)
    {
        var command = new CreateDocumentCommand(dto);
        var document = await Mediator.Send(command, cancellationToken);
        return StatusCode(StatusCodes.Status201Created, document);
    }

    [HttpGet("--query")]
    public async Task<IActionResult> Query(CancellationToken cancellationToken)
    {
        var query = new GetDocumentsQuery();
        var documents = await Mediator.Send(query, cancellationToken);
        return Ok(documents);
    }

    [HttpPut("{documentId:long}")]
    public async Task<IActionResult> Edit(
        [FromRoute] long documentId,
        [FromBody] Dto.Document dto,
        CancellationToken cancellationToken)
    {
        var command = new EditDocumentCommand(documentId, dto);
        var document = Mediator.Send(command, cancellationToken);
        return Ok(document);
    }

    [HttpDelete("{documentId:long}")]
    public async Task<IActionResult> Delete(
        [FromRoute] long documentId,
        CancellationToken cancellationToken)
    {
        var command = new DeleteDocumentCommand(documentId);
        await Mediator.Send(command, cancellationToken);
        return Ok();
    }
    
}