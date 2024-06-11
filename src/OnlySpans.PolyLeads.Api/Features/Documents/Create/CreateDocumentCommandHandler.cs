using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using OnlySpans.PolyLeads.Api.Data.Abstractions.Commands;
using OnlySpans.PolyLeads.Api.Data.Contexts;
using OnlySpans.PolyLeads.Api.Data.Entities;
using OnlySpans.PolyLeads.Api.Data.Enums;
using OnlySpans.PolyLeads.Api.Data.Records;
using OnlySpans.PolyLeads.Api.Exceptions;
using OnlySpans.PolyLeads.Api.Extensions;
using OnlySpans.PolyLeads.Api.Features.Documents.FindSource;

namespace OnlySpans.PolyLeads.Api.Features.Documents.Create;

[UsedImplicitly]
public sealed record CreateDocumentCommand :
    IRequest<Document>,
    ICalledByUser
{
    public required string Name { get; init; }

    public required string Description { get; init; }

    public required Uri DownloadUrl { get; init; }

    public MaybeSet<Identity?> User { get; set; }
}

[UsedImplicitly]
public sealed class CreateDocumentCommandHandler :
    IRequestHandler<CreateDocumentCommand, Document>
{
    private readonly ApplicationDbContext _context;
    private readonly TimeProvider _timeProvider;
    private readonly ISender _sender;

    public CreateDocumentCommandHandler(
        ApplicationDbContext context,
        TimeProvider timeProvider,
        ISender sender)
    {
        _context = context;
        _timeProvider = timeProvider;
        _sender = sender;
    }

    public async ValueTask<Document> Handle(
        CreateDocumentCommand request,
        CancellationToken cancellationToken)
    {
        var downloadUrl = request.DownloadUrl;

        var source = await _sender
           .Send(new FindPermittedSourceQuery(downloadUrl), cancellationToken);

        if (source is null)
            throw new UnpermittedResourceException($"Ресурс {downloadUrl} не является доверенным");

        var now = _timeProvider.GetUtcNow().UtcDateTime;

        var document = new Document
        {
            Name = request.Name,
            Description = request.Description,
            DownloadUrl = downloadUrl,
            CreatedById = request.GetUser().Id,
            CreatedAt = now,
            RecognitionStatus = RecognitionStatus.Queued,
            Source = source
        };

        await _context
            .Documents
            .AddAsync(document, cancellationToken);

        await _context
            .SaveChangesAsync(cancellationToken);

        return await _context
           .Documents
           .IncludeAuditProperties()
           .FirstAsync(x => x.Id == document.Id, cancellationToken);
    }
}
