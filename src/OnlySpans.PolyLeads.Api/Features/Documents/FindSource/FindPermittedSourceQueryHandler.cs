using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using OnlySpans.PolyLeads.Api.Data.Contexts;

namespace OnlySpans.PolyLeads.Api.Features.Documents.FindSource;

public sealed record FindPermittedSourceQuery(Uri ResourceUri) :
    IRequest<Entities.PermittedSource?>;

[UsedImplicitly]
public sealed class FindPermittedSourceQueryHandler :
    IRequestHandler<FindPermittedSourceQuery, Entities.PermittedSource?>
{
    private readonly ApplicationDbContext _context;

    public FindPermittedSourceQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Entities.PermittedSource?> Handle(
        FindPermittedSourceQuery request,
        CancellationToken cancellationToken)
    {
        var permittedUrls = await _context
           .PermittedSources
           .ToListAsync(cancellationToken);

        return permittedUrls
           .FirstOrDefault(x => x.BaseUrl.IsBaseOf(request.ResourceUri));
    }
}
