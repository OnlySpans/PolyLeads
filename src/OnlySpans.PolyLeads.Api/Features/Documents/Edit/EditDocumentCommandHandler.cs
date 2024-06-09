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

    public required Guid UserId { get; init; }
}

[UsedImplicitly]
public sealed class EditDocumentCommandHandler
    : IRequestHandler<EditDocumentCommand, Entities.Document>
{
    private readonly IMapper _mapper;
    private readonly TimeProvider _timeProvider;
    private readonly ApplicationDbContext _context;

    public EditDocumentCommandHandler(
        IMapper mapper,
        TimeProvider timeProvider,
        ApplicationDbContext context)
    {
        _mapper = mapper;
        _timeProvider = timeProvider;
        _context = context;
    }

    public async Task<Entities.Document> Handle(
        EditDocumentCommand request,
        CancellationToken cancellationToken)
    {
        var documentId = request.DocumentId;

        var @ref = await _context
            .Documents
            .WhereIsNotDeleted()
            .FirstOrDefaultAsync(
                x => x.Id == documentId,
                cancellationToken);

        ResourceNotFoundException.ThrowIfNull(
            @ref,
            $"Документ с id {documentId} не найден");

        _mapper
            .From(request)
            .AdaptTo(@ref);

        @ref.UpdatedById = request.UserId;
        @ref.UpdatedAt = _timeProvider.GetUtcNow().UtcDateTime;

        await _context
            .SaveChangesAsync(cancellationToken);

        return await _context
           .Documents
           .IncludeAuditProperties()
           .FirstAsync(x => x.Id == @ref.Id, cancellationToken);
    }
}
