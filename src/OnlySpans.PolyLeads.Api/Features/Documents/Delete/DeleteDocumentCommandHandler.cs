using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using OnlySpans.PolyLeads.Api.Data.Abstractions.Commands;
using OnlySpans.PolyLeads.Api.Data.Contexts;
using OnlySpans.PolyLeads.Api.Data.Records;
using OnlySpans.PolyLeads.Api.Exceptions;
using OnlySpans.PolyLeads.Api.Extensions;

namespace OnlySpans.PolyLeads.Api.Features.Documents.Delete;

public sealed record DeleteDocumentCommand(long DocumentId) : 
    IRequest,
    ICalledByUser
{
    public MaybeSet<Identity?> User { get; set; }
}

[UsedImplicitly]
public sealed class DeleteDocumentCommandHandler :
    IRequestHandler<DeleteDocumentCommand>
{
    private readonly ApplicationDbContext _context;
    private readonly TimeProvider _timeProvider;

    public DeleteDocumentCommandHandler(
        ApplicationDbContext context,
        TimeProvider timeProvider)
    {
        _context = context;
        _timeProvider = timeProvider;
    }

    public async ValueTask<Unit> Handle(
        DeleteDocumentCommand request,
        CancellationToken cancellationToken)
    {
        var documentToDelete = await _context
            .Documents
            .WhereIsNotDeleted()
            .FirstOrDefaultAsync(
                x => x.Id == request.DocumentId,
                cancellationToken);

        ResourceNotFoundException.ThrowIfNull(
            documentToDelete,
            $"Документ с id {request.DocumentId} не найден");

        documentToDelete.DeletedAt = _timeProvider.GetUtcNow().UtcDateTime;
        documentToDelete.DeletedById = request.GetUser().Id;

        await _context
            .SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
