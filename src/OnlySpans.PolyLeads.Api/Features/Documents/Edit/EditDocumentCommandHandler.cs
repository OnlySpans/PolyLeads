using JetBrains.Annotations;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

using OnlySpans.PolyLeads.Api.Data.Contexts;
using OnlySpans.PolyLeads.Api.Exceptions;
using OnlySpans.PolyLeads.Api.Extensions;

namespace OnlySpans.PolyLeads.Api.Features.Documents.Edit;

public sealed record EditDocumentCommand :
    IRequest<Entities.Document>
{
    public required long DocumentId { get; init; }

    public required string Name { get; init; }

    public required string Description { get; init; }

    public required Uri DownloadUrl { get; init; }

    public required Guid UserId { get; init; }
}

[UsedImplicitly]
public sealed class EditDocumentCommandHandler
    : IRequestHandler<EditDocumentCommand, Entities.Document>
{
    private IMapper Mapper { get; init; }
    private TimeProvider TimeProvider { get; init; }
    private ApplicationDbContext Context { get; init; }

    public EditDocumentCommandHandler(
        IMapper mapper,
        TimeProvider timeProvider,
        ApplicationDbContext context)
    {
        Mapper = mapper;
        TimeProvider = timeProvider;
        Context = context;
    }

    public async Task<Entities.Document> Handle(
        EditDocumentCommand request,
        CancellationToken cancellationToken)
    {
        var documentId = request.DocumentId;

        var @ref = await Context
            .Documents
            .FirstOrDefaultAsync(
                x => x.Id == documentId,
                cancellationToken);

        ResourceNotFoundException.ThrowIfNull(
            @ref,
            $"Документ с id {documentId} не найден");

        Mapper
            .From(request)
            .AdaptTo(@ref);

        @ref.UpdatedById = request.UserId;
        @ref.UpdatedAt = TimeProvider.GetUtcNow().DateTime;

        await Context
            .SaveChangesAsync(cancellationToken);

        return await Context
           .Documents
           .IncludeAuditProperties()
           .FirstAsync(x => x.Id == @ref.Id, cancellationToken);
    }
}
