using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlySpans.PolyLeads.Api.Data.Contexts;

namespace OnlySpans.PolyLeads.Api.Features.Documents;

using Dto = Dto.Data;

public sealed record GetDocumentsQuery : IRequest<IReadOnlyList<Dto.Document>>;

public sealed class GetDocumentsQueryHandler
    : IRequestHandler<GetDocumentsQuery, IReadOnlyList<Dto.Document>>
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

    public async Task<IReadOnlyList<Dto.Document>> Handle(
        GetDocumentsQuery request,
        CancellationToken cancellationToken)
    {
        var query = Context
            .Documents
            .ProjectToType<Dto.Document>(Mapper.Config);

        return await query
            .ToListAsync(cancellationToken);
    }
}