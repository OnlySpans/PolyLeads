using OnlySpans.PolyLeads.Api.Data.Records;
using OnlySpans.PolyLeads.Api.Exceptions;
using OnlySpans.PolyLeads.Api.Features.Documents.Create;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace OnlySpans.PolyLeads.Api.Features.Seeding;

public sealed record DocumentSeedCommand : IRequest
{
    public required string FilePath { get; init; }

    public required Guid Id { get; init; }
}

public sealed class DocumentSeedCommandHandler : IRequestHandler<DocumentSeedCommand>
{
    private readonly ISender _sender;

    public DocumentSeedCommandHandler(ISender sender)
    {
        _sender = sender;
    }

    public async ValueTask<Unit> Handle(
        DocumentSeedCommand request,
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

        if (documents == null)
        {
            throw new ResourceNotFoundException("Документы не загрузились");
        }

        foreach (var document in documents)
        {
            await _sender.Send(new CreateDocumentCommand
            {
                Name = document.Name,
                Description = document.Description,
                DownloadUrl = document.DownloadUrl,
                User = new MaybeSet<Identity?>
                {
                    Value = new Identity(request.Id),
                    WasSet = true
                }
            }, cancellationToken);
        }

        return Unit.Value;
    }
}