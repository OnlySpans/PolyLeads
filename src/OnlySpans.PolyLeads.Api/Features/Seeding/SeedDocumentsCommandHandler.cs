using OnlySpans.PolyLeads.Api.Data.Records;
using OnlySpans.PolyLeads.Api.Exceptions;
using OnlySpans.PolyLeads.Api.Features.Documents.Create;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace OnlySpans.PolyLeads.Api.Features.Seeding;

public sealed record SeedDocumentCommand(string FilePath, Guid UserId) : IRequest;

public sealed class SeedDocumentsCommandHandler : IRequestHandler<SeedDocumentCommand>
{
    private readonly ISender _sender;

    public SeedDocumentsCommandHandler(ISender sender)
    {
        _sender = sender;
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