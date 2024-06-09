using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

using OnlySpans.PolyLeads.Api.Data.Contexts;
using OnlySpans.PolyLeads.Api.Data.Entities;
using OnlySpans.PolyLeads.Api.Data.Enums;
using OnlySpans.PolyLeads.Api.Exceptions;
using OnlySpans.PolyLeads.Api.Extensions;
using OnlySpans.PolyLeads.Api.Features.Documents.FindSource;
using OnlySpans.PolyLeads.Api.Utils;

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
    private ISender Sender { get; init; }

    public CreateDocumentCommandHandler(
        ApplicationDbContext context,
        TimeProvider timeProvider,
        ISender sender)
    {
        Context = context;
        TimeProvider = timeProvider;
        Sender = sender;
    }

    public async Task<Document> Handle(
        CreateDocumentCommand request,
        CancellationToken cancellationToken)
    {
        var downloadUrl = request.DownloadUrl;

        var source = await Sender
           .Send(new FindPermittedSourceQuery(downloadUrl), cancellationToken);

        if (source is null)
            throw new UnpermittedResourceException($"Ресурс {downloadUrl} не является доверенным");

        var now = TimeProvider.GetUtcNow().UtcDateTime;

        var document = new Document
        {
            Name = request.Name,
            Description = request.Description,
            DownloadUrl = downloadUrl,
            CreatedById = request.UserId,
            CreatedAt = now,
            RecognitionStatus = RecognitionStatus.Queued,
            Source = source
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
