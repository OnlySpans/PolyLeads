using JetBrains.Annotations;
using Marten;
using OnlySpans.PolyLeads.Api.Data.Contexts;
using OnlySpans.PolyLeads.Api.Extensions;

namespace OnlySpans.PolyLeads.Api.Features.Documents.Search;

public sealed record SearchDocumentsQuery(string SearchTerm) :
    IRequest<IQueryable<Entities.Document>>;

[UsedImplicitly]
public sealed class SearchDocumentsQueryHandler :
    IRequestHandler<SearchDocumentsQuery, IQueryable<Entities.Document>>
{
    private readonly IQuerySession _session;
    private readonly ApplicationDbContext _context;

    public SearchDocumentsQueryHandler(
        IQuerySession session,
        ApplicationDbContext context)
    {
        _session = session;
        _context = context;
    }

    public async Task<IQueryable<Entities.Document>> Handle(
        SearchDocumentsQuery request,
        CancellationToken cancellationToken)
    {
        var searchTerm = request.SearchTerm.ToLower();

        var documentIds = await _session
           .Query<Entities.RecognitionResult>()
           .Where(x => x.Content.WebStyleSearch(searchTerm, "russian")
                    || x.Content.NgramSearch(searchTerm)
                    || x.Content.PlainTextSearch(searchTerm, "russian"))
           .Select(x => x.DocumentId)
           .ToListAsync(cancellationToken);

        var query = _context
           .Documents
           .WhereIsNotDeleted()
           .Where(x => x.Name.ToLower().Contains(searchTerm)
                    || x.Description.ToLower().Contains(searchTerm)
                    || documentIds.Contains(x.Id));

        return query;
    }
}
