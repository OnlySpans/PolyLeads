using MapsterMapper;
using OnlySpans.PolyLeads.Api.Data.Contexts;
using OnlySpans.PolyLeads.Api.Data.Entities;

namespace OnlySpans.PolyLeads.Api.Features.Documents.Create;

using Dto = Dto.Data;

public sealed record CreateDocumentCommand(Dto.Document Document, Guid UserId) :
    IRequest<Dto.DetailedDocument>;

public sealed class CreateDocumentCommandHandler :
    IRequestHandler<CreateDocumentCommand, Dto.DetailedDocument>
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

    public async Task<Dto.DetailedDocument> Handle(
        CreateDocumentCommand request,
        CancellationToken cancellationToken)
    {
        // fuck it
        var document = new Document
        {
            Name = request.Document.Name,
            Description = request.Document.Description,
            Link = request.Document.Link,
            CreatedById = request.UserId,
            CreatedAt = DateTime.UtcNow,
            UpdatedById = request.UserId,
            UpdatedAt = DateTime.UtcNow
        };

        await Context
            .Documents
            .AddAsync(document, cancellationToken);

        await Context
            .SaveChangesAsync(cancellationToken);

        // fuck it again
        await Context
            .Entry(document)
            .Reference(x => x.CreatedBy)
            .LoadAsync(cancellationToken);

        await Context
            .Entry(document)
            .Reference(x => x.UpdatedBy)
            .LoadAsync(cancellationToken);

        return Mapper.Map<Dto.DetailedDocument>(document);
    }
}