using Microsoft.EntityFrameworkCore;
using OnlySpans.PolyLeads.Api.Data.Contexts;

namespace OnlySpans.PolyLeads.Api.Features.Documents.FindSource;

public sealed record FindPermittedSourceQuery(Uri ResourceUri) :
    IRequest<Entities.PermittedSource?>;

public sealed class FindPermittedSourceQueryHandler :
    IRequestHandler<FindPermittedSourceQuery, Entities.PermittedSource?>
{
    private ApplicationDbContext Context { get; init; }

    public FindPermittedSourceQueryHandler(ApplicationDbContext context)
    {
        Context = context;
    }

    public async Task<Entities.PermittedSource?> Handle(
        FindPermittedSourceQuery request,
        CancellationToken cancellationToken)
    {
        var permittedUrls = await Context
           .PermittedSources
           .ToListAsync(cancellationToken);

        return permittedUrls
           .FirstOrDefault(x => x.BaseUrl.IsBaseOf(request.ResourceUri));
    }
}
