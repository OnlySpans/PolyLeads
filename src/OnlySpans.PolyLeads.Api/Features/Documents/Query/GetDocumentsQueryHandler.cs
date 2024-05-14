using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using OnlySpans.PolyLeads.Api.Data.Contexts;

namespace OnlySpans.PolyLeads.Api.Features.Documents.Query;

using Dto = Dto.Data;

public sealed record GetDocumentsQuery : IRequest<IReadOnlyList<Dto.DetailedDocument>>;

public sealed class GetDocumentsQueryHandler
    : IRequestHandler<GetDocumentsQuery, IReadOnlyList<Dto.DetailedDocument>>
{
    private ApplicationDbContext Context { get; init; }

    private IMapper Mapper { get; init; }

    public GetDocumentsQueryHandler(
        IMapper mapper,
        ApplicationDbContext context)
    {
        Mapper = mapper;
        Context = context;
    }

    public async Task<IReadOnlyList<Dto.DetailedDocument>> Handle(
        GetDocumentsQuery request,
        CancellationToken cancellationToken)
    {
        var query = Context
            .Documents
            .ProjectToType<Dto.DetailedDocument>(Mapper.Config);

        return await query
            .ToListAsync(cancellationToken);
    }
}