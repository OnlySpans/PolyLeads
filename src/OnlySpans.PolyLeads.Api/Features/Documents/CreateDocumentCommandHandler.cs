using MapsterMapper;
using MediatR;
using OnlySpans.PolyLeads.Api.Data.Contexts;
using OnlySpans.PolyLeads.Api.Data.Entities;

namespace OnlySpans.PolyLeads.Api.Features.Documents;

using Dto = Dto.Data;

public sealed record CreateDocumentCommand(Dto.Document Document)
    : IRequest<Dto.Document>;

public sealed class CreateDocumentCommandHandler
    : IRequestHandler<CreateDocumentCommand, Dto.Document>
{
    private ApplicationDbContext Context { get; init; }

    private IMapper Mapper { get; init; }

    public CreateDocumentCommandHandler(
        ApplicationDbContext context,
        IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    public async Task<Dto.Document> Handle(
        CreateDocumentCommand request,
        CancellationToken cancellationToken)
    {
        var document = Mapper.Map<Document>(request.Document);

        await Context
            .Documents
            .AddAsync(document, cancellationToken);

        await Context
            .SaveChangesAsync(cancellationToken);

        return Mapper.Map<Dto.Document>(document);
    }
}