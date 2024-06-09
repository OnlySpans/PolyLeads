using JetBrains.Annotations;
using OnlySpans.PolyLeads.Api.Data.Contexts;
using OnlySpans.PolyLeads.Api.Extensions;

namespace OnlySpans.PolyLeads.Api.Features.Documents.Query;

public sealed record GetDocumentsQuery :
    IRequest<IQueryable<Entities.Document>>;

[UsedImplicitly]
public sealed class GetDocumentsQueryHandler
    : IRequestHandler<GetDocumentsQuery, IQueryable<Entities.Document>>
{
    private readonly ApplicationDbContext _context;

    public GetDocumentsQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public ValueTask<IQueryable<Entities.Document>> Handle(
        GetDocumentsQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context
           .Documents
           .WhereIsNotDeleted()
           .IncludeAuditProperties();

        return ValueTask.FromResult(query);
    }
}
