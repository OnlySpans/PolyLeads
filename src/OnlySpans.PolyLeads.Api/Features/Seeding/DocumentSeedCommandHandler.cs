using Microsoft.AspNetCore.Identity;
using OnlySpans.PolyLeads.Api.Data.Records;
using OnlySpans.PolyLeads.Api.Exceptions;
using OnlySpans.PolyLeads.Api.Features.Documents.Create;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace OnlySpans.PolyLeads.Api.Features.Seeding;

public sealed record DocumentSeedCommand : IRequest
{
    //public string FilePath { get;} = ;
}

public sealed class DocumentSeedCommandHandler : IRequestHandler<DocumentSeedCommand>
{
    private readonly ISender _sender;

    private readonly UserManager<Entities.ApplicationUser> _userManager;

    public DocumentSeedCommandHandler(
        ISender sender,
        UserManager<Entities.ApplicationUser> userManager)
    {
        _sender = sender;
        _userManager = userManager;
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

        using StreamReader reader = new(filepath);

        var json = await reader.ReadToEndAsync(cancellationToken);

        var documents = JsonSerializer.Deserialize<List<DocumentSeed>>(json);

        if (documents == null)
        {
            throw new ResourceNotFoundException("Документов нет");
        }

        foreach (var document in documents)
        {
            await _sender.Send(new CreateDocumentCommand
            {
                Name = document.Name,
                Description = document.Description,
                DownloadUrl = document.DownloadUrl,
                //User = 
            }, cancellationToken);
        }

        return Unit.Value;
    }
}