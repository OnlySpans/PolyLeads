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
    private IQuerySession Session { get; init; }
    private ApplicationDbContext Context { get; init; }

    public SearchDocumentsQueryHandler(
        IQuerySession session,
        ApplicationDbContext context)
    {
        Session = session;
        Context = context;
    }

    public async Task<IQueryable<Entities.Document>> Handle(
        SearchDocumentsQuery request,
        CancellationToken cancellationToken)
    {
        var searchTerm = request.SearchTerm.ToLower();

        var documentIds = await Session
           .Query<Entities.RecognitionResult>()
           .Where(x => x.Content.WebStyleSearch(searchTerm, "russian")
                    || x.Content.NgramSearch(searchTerm)
                    || x.Content.PlainTextSearch(searchTerm, "russian"))
           .Select(x => x.DocumentId)
           .ToListAsync(cancellationToken);

        var query = Context
           .Documents
           .WhereIsNotDeleted()
           .Where(x => x.Name.ToLower().Contains(searchTerm)
                    || x.Description.ToLower().Contains(searchTerm)
                    || documentIds.Contains(x.Id));

        return query;
    }
}
