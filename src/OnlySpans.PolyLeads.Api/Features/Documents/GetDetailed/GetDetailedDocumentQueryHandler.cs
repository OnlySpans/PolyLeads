using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using OnlySpans.PolyLeads.Api.Data.Contexts;
using OnlySpans.PolyLeads.Api.Exceptions;

namespace OnlySpans.PolyLeads.Api.Features.Documents.GetDetailed;

using Dto = Dto.Data;

public sealed record GetDetailedDocumentQuery(long DocumentId)
    : IRequest<Dto.DetailedDocument>;

public sealed class GetDetailedDocumentQueryHandler
    : IRequestHandler<GetDetailedDocumentQuery, Dto.DetailedDocument>
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

    public async Task<Dto.DetailedDocument> Handle(
        GetDetailedDocumentQuery request,
        CancellationToken cancellationToken)
    {
        var document = await Context
            .Documents
            .Include(x => x.CreatedBy)
            .Include(x => x.UpdatedBy)
            .Include(x => x.DeletedBy)
            .FirstOrDefaultAsync(
                x => x.Id == request.DocumentId,
                cancellationToken);

        ResourceNotFoundException.ThrowIfNull(
            document,
            $"Документ с id {request.DocumentId} не найден");

        return Mapper.Map<Dto.DetailedDocument>(document);
    }
}