using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using OnlySpans.PolyLeads.Api.Data.Contexts;
using OnlySpans.PolyLeads.Api.Exceptions;
using OnlySpans.PolyLeads.Api.Extensions;

namespace OnlySpans.PolyLeads.Api.Features.Documents.GetDetailed;

public sealed record GetDetailedDocumentQuery(long DocumentId)
    : IRequest<Entities.Document>;

[UsedImplicitly]
public sealed class GetDetailedDocumentQueryHandler
    : IRequestHandler<GetDetailedDocumentQuery, Entities.Document>
{
    private readonly ApplicationDbContext _context;

    public GetDetailedDocumentQueryHandler(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Entities.Document> Handle(
        GetDetailedDocumentQuery request,
        CancellationToken cancellationToken)
    {
        var document = await _context
            .Documents
            .WhereIsNotDeleted()
            .IncludeAuditProperties()
            .FirstOrDefaultAsync(
                x => x.Id == request.DocumentId,
                cancellationToken);

        ResourceNotFoundException.ThrowIfNull(
            document,
            $"Документ с id {request.DocumentId} не найден");

        return document;
    }
}
