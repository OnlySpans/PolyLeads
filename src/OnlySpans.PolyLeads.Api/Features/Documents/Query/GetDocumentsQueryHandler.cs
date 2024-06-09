using OnlySpans.PolyLeads.Api.Data.Contexts;
using OnlySpans.PolyLeads.Api.Extensions;

namespace OnlySpans.PolyLeads.Api.Features.Documents.Query;

public sealed record GetDocumentsQuery :
    IRequest<IQueryable<Entities.Document>>;

public sealed class GetDocumentsQueryHandler
    : IRequestHandler<GetDocumentsQuery, IQueryable<Entities.Document>>
{
    private ApplicationDbContext Context { get; init; }

    public GetDocumentsQueryHandler(ApplicationDbContext context)
    {
        Context = context;
    }

    public Task<IQueryable<Entities.Document>> Handle(
        GetDocumentsQuery request,
        CancellationToken cancellationToken)
    {
        var query = Context
           .Documents
           .WhereIsNotDeleted()
           .IncludeAuditProperties();

        return Task.FromResult(query);
    }
}
