using HotChocolate.Types;
using JasperFx.Core;
using Microsoft.AspNetCore.Identity;
using OnlySpans.PolyLeads.Api.Data.Options;
using OnlySpans.PolyLeads.Api.Data.Records;
using OnlySpans.PolyLeads.Api.Exceptions;
using OnlySpans.PolyLeads.Api.Features.Documents.Create;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace OnlySpans.PolyLeads.Api.Features.Seeding;

public sealed record DocumentSeedCommand : IRequest
{
    public string FilePath { get; } = Path.GetFullPath(@"..\\OnlySpans.PolyLeads.Api\\documents-seed.json");
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

        using var stream = File.OpenRead(filepath);

        var documents = await JsonSerializer
           .DeserializeAsync<List<DocumentSeed>>(
                stream,
                cancellationToken: cancellationToken);

        if (documents == null)
        {
            throw new ResourceNotFoundException("Документы не загрузились");
        }

        var adminUsers = await _userManager
           .GetUsersInRoleAsync("Admin");

        if (adminUsers == null)
        {
            throw new ResourceNotFoundException("Пользователей с правами админа нет");
        }

        var adminUser = adminUsers.First();

        foreach (var document in documents)
        {
            await _sender.Send(new CreateDocumentCommand
            {
                Name = document.Name,
                Description = document.Description,
                DownloadUrl = document.DownloadUrl,
                User = new MaybeSet<Identity?>
                {
                    Value = new Identity(adminUser.Id),
                    WasSet = true
                }
            }, cancellationToken);
        }

        return Unit.Value;
    }
}