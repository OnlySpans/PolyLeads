using Microsoft.EntityFrameworkCore;
using OnlySpans.PolyLeads.Api.Data.Contexts;
using OnlySpans.PolyLeads.Api.Data.Records;
using OnlySpans.PolyLeads.Api.Exceptions;
using OnlySpans.PolyLeads.Api.Features.Documents.Create;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace OnlySpans.PolyLeads.Api.Features.Seeding;

public sealed record SeedDocumentCommand(string FilePath, Guid UserId) : IRequest;

public sealed class SeedDocumentsCommandHandler : IRequestHandler<SeedDocumentCommand>
{
    private readonly ISender _sender;

    private readonly ApplicationDbContext _context;

    public SeedDocumentsCommandHandler(ISender sender, ApplicationDbContext context)
    {
        _sender = sender;
        _context = context;
    }

    public async ValueTask<Unit> Handle(
        SeedDocumentCommand request,
        CancellationToken cancellationToken)
    {
        var filepath = request.FilePath;

        if (!File.Exists(filepath))
        {
            throw new ResourceNotFoundException($"Файл с путем {filepath} не найден");
        }

        using var stream = File.OpenRead(filepath);

        var documents = await JsonSerializer
           .DeserializeAsync<List<DocumentSeed>>(
                stream,
                cancellationToken: cancellationToken);

        if (documents is null)
        {
            throw new InvalidOperationException("Ошибка десериализации документов");
        }

        foreach (var document in documents)
        {
            var isSameDocumentInDb = await _context
               .Documents
               .AnyAsync(x =>
                    x.Name == document.Name,
                    cancellationToken);

            if (isSameDocumentInDb)
            {
                continue;
            }

            await _sender.Send(new CreateDocumentCommand
            {
                Name = document.Name,
                Description = document.Description,
                DownloadUrl = document.DownloadUrl,
                User = new MaybeSet<Identity?>
                {
                    Value = new Identity(request.UserId),
                    WasSet = true
                }
            }, cancellationToken);
        }

        return Unit.Value;
    }
}