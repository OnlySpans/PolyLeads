using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using OnlySpans.PolyLeads.Api.Data.Contexts;
using OnlySpans.PolyLeads.Api.Exceptions;

namespace OnlySpans.PolyLeads.Api.Features.Documents.Edit;

using Dto = Dto.Data;

public sealed record EditDocumentCommand(
    long DocumentId,
    Dto.Document Document,
    Guid UserId)
    : IRequest<Dto.Document>;

public sealed class EditDocumentCommandHandler
    : IRequestHandler<EditDocumentCommand, Dto.Document>
{
    private ApplicationDbContext Context { get; init; }

    private IMapper Mapper { get; init; }

    public EditDocumentCommandHandler(ApplicationDbContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }


    public async Task<Dto.Document> Handle(
        EditDocumentCommand request,
        CancellationToken cancellationToken)
    {
        var (documentId, @new, userId) = request;

        var @ref = await Context
            .Documents
            .FirstOrDefaultAsync(
                x => x.Id == documentId,
                cancellationToken);

        ResourceNotFoundException.ThrowIfNull(
            @ref,
            $"Документ с id {documentId} не найден");

        Mapper
            .From(@new)
            .AdaptTo(@ref);

        @ref.UpdatedById = userId;
        @ref.UpdatedAt = DateTime.UtcNow;

        await Context
            .SaveChangesAsync(cancellationToken);

        return Mapper
            .Map<Dto.Document>(@ref);
    }
}