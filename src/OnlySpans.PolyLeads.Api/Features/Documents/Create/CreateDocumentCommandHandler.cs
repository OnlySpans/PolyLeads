using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

using OnlySpans.PolyLeads.Api.Data.Contexts;
using OnlySpans.PolyLeads.Api.Data.Entities;
using OnlySpans.PolyLeads.Api.Data.Enums;
using OnlySpans.PolyLeads.Api.Extensions;

namespace OnlySpans.PolyLeads.Api.Features.Documents.Create;

[UsedImplicitly]
public sealed record CreateDocumentCommand :
    IRequest<Document>
{
    public required string Name { get; init; }

    public required string Description { get; init; }

    public required Uri DownloadUrl { get; init; }

    public required Guid UserId { get; init; }
}

[UsedImplicitly]
public sealed class CreateDocumentCommandHandler :
    IRequestHandler<CreateDocumentCommand, Document>
{
    private ApplicationDbContext Context { get; init; }
    private TimeProvider TimeProvider { get; init; }

    public CreateDocumentCommandHandler(
        ApplicationDbContext context,
        TimeProvider timeProvider)
    {
        Context = context;
        TimeProvider = timeProvider;
    }

    public async Task<Document> Handle(
        CreateDocumentCommand request,
        CancellationToken cancellationToken)
    {
        var now = TimeProvider.GetUtcNow().UtcDateTime;

        var document = new Document
        {
            Name = request.Name,
            Description = request.Description,
            DownloadUrl = request.DownloadUrl,
            CreatedById = request.UserId,
            CreatedAt = now,
            RecognitionStatus = RecognitionStatus.Queued
        };

        await Context
            .Documents
            .AddAsync(document, cancellationToken);

        await Context
            .SaveChangesAsync(cancellationToken);

        return await Context
           .Documents
           .IncludeAuditProperties()
           .FirstAsync(x => x.Id == document.Id, cancellationToken);
    }
}
