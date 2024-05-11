using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlySpans.PolyLeads.Api.Data.Contexts;
using OnlySpans.PolyLeads.Api.Exceptions;

namespace OnlySpans.PolyLeads.Api.Features.Documents.Delete;

public sealed record DeleteDocumentCommand(
    long DocumentId,
    Guid UserId) : IRequest;

public sealed class DeleteDocumentCommandHandler : IRequestHandler<DeleteDocumentCommand>
{
    private ApplicationDbContext Context { get; init; }

    public DeleteDocumentCommandHandler(ApplicationDbContext context)
    {
        Context = context;
    }

    public async Task Handle(
        DeleteDocumentCommand request,
        CancellationToken cancellationToken)
    {
        var documentToDelete = await Context
            .Documents
            .FirstOrDefaultAsync(
                x => x.Id == request.DocumentId,
                cancellationToken);
        
        ResourceNotFoundException.ThrowIfNull(
            documentToDelete, 
            $"Документ с id {request.DocumentId} не найден");

        documentToDelete.DeletedAt = DateTime.UtcNow;
        documentToDelete.DeletedById = request.UserId;

        await Context
            .SaveChangesAsync(cancellationToken);
    }
}