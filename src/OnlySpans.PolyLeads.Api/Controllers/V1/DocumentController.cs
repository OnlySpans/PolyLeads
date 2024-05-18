using Mapster;
using MapsterMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlySpans.PolyLeads.Api.Controllers.Abstractions;
using OnlySpans.PolyLeads.Api.Extensions;
using OnlySpans.PolyLeads.Api.Features.Documents.Create;
using OnlySpans.PolyLeads.Api.Features.Documents.Delete;
using OnlySpans.PolyLeads.Api.Features.Documents.Edit;
using OnlySpans.PolyLeads.Api.Features.Documents.GetDetailed;
using OnlySpans.PolyLeads.Api.Features.Documents.Query;
using OnlySpans.PolyLeads.Api.Features.Documents.Search;

namespace OnlySpans.PolyLeads.Api.Controllers.V1;

using Dto = Dto.Documents;

[Route("/api/v1/document")]
public sealed class DocumentController(IMediator mediator, IMapper mapper) :
    ApplicationController(mediator, mapper)
{
    [HttpGet]
    public async Task<IActionResult> Query(
        [FromQuery(Name = "q")] string? searchTerm,
        CancellationToken cancellationToken)
    {
        IRequest<IQueryable<Entities.Document>> query = searchTerm is null
            ? new GetDocumentsQuery()
            : new SearchDocumentsQuery(searchTerm);

        var documents = await Mediator.Send(query, cancellationToken);

        var result = await documents
           .ProjectToType<Dto.Document>(Mapper.Config)
           .ToListAsync(cancellationToken);

        return Ok(result);
    }

    [HttpGet("{documentId:long}")]
    public async Task<IActionResult> GetDetailed(
        [FromRoute] long documentId,
        CancellationToken cancellationToken)
    {
        var query = new GetDetailedDocumentQuery(documentId);
        var detailedDocument = await Mediator.Send(query, cancellationToken);
        return Ok(Mapper.Map<Dto.DetailedDocument>(detailedDocument));
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] Dto.CreateDocumentInput dto,
        CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();
        var command = Mapper.Map<CreateDocumentCommand>(dto) with {UserId = userId};
        var document = await Mediator.Send(command, cancellationToken);
        return Created(Mapper.Map<Dto.DetailedDocument>(document));
    }

    [Authorize]
    [HttpPut("{documentId:long}")]
    public async Task<IActionResult> Edit(
        [FromRoute] long documentId,
        [FromBody] Dto.EditDocumentInput dto,
        CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();
        var command = Mapper.Map<EditDocumentCommand>(dto) with { DocumentId = documentId, UserId = userId };
        var document = await Mediator.Send(command, cancellationToken);
        return Ok(Mapper.Map<Dto.DetailedDocument>(document));
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
