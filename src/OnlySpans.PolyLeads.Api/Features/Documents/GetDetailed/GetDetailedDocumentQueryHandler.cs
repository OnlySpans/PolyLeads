using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using OnlySpans.PolyLeads.Api.Data.Contexts;
using OnlySpans.PolyLeads.Api.Exceptions;
using OnlySpans.PolyLeads.Api.Extensions;

namespace OnlySpans.PolyLeads.Api.Features.Documents.GetDetailed;

public sealed record GetDetailedDocumentQuery(long DocumentId)
    : IRequest<Entities.Document>;

public sealed class GetDetailedDocumentQueryHandler
    : IRequestHandler<GetDetailedDocumentQuery, Entities.Document>
{
    private ApplicationDbContext Context { get; init; }

    private IMapper Mapper { get; init; }

    public GetDetailedDocumentQueryHandler(
        ApplicationDbContext context,
        IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    public async Task<Entities.Document> Handle(
        GetDetailedDocumentQuery request,
        CancellationToken cancellationToken)
    {
        var document = await Context
            .Documents
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
