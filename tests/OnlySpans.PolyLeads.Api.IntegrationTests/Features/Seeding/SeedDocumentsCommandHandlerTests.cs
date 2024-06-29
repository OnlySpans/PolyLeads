using Microsoft.EntityFrameworkCore;
using OnlySpans.PolyLeads.Api.Data.Entities;
using OnlySpans.PolyLeads.Api.Features.Seeding;
using OnlySpans.PolyLeads.Api.Tests.Tools;

namespace OnlySpans.PolyLeads.Api.Tests.Features.Seeding;

public sealed class SeedDocumentsCommandHandlerTests : DatabaseTests
{
    private SeedDocumentsCommandHandler Handler { get; set; } = default!;

    protected override async Task InitializeAsync()
    {
        Handler = new(Sender);
    }

    [Fact]
    public async Task Should_create_file_by_admin()
    {
        // Arrange
        var user = new ApplicationUser()
        {
            UserName = "Berkas",
            FirstName = "Vivo",
            LastName = "ASFasf"
        };

        await UserManager
           .CreateAsync(user, "1234567");

        var masterUser = await UserManager
           .FindByNameAsync("Berkas");

        var userId = masterUser!.Id;

        var filePath = "Resources/documents-seed-test.json";

        var command = new SeedDocumentCommand(filePath, userId);

        // Act
        await Handler
           .Handle(command, CancellationToken.None);

        // Assert
        var expected = new Document
        {
            Name = "Устав образовательной организации",
            Description = "sbabab",
            DownloadUrl = new Uri("https://www.spbstu.ru/upload/administration-catalogue/ustav-18-03-21.pdf"),
            CreatedById = userId
        };

        var createdDocument = await Context
           .Documents
           .FirstAsync();

        createdDocument
           .Name
           .Should()
           .Be(expected.Name);

        createdDocument
           .Description
           .Should()
           .Be(expected.Description);

        createdDocument
           .DownloadUrl
           .Should()
           .Be(expected.DownloadUrl);

        createdDocument
           .CreatedById
           .Should()
           .Be(expected.CreatedById);
    }

    [Fact]
    public async Task Should_create_files_by_admin()
    {
        // Arrange
        var user = new ApplicationUser()
        {
            UserName = "Berkas",
            FirstName = "Vivo",
            LastName = "ASFasf"
        };

        await UserManager
           .CreateAsync(user, "1234567");

        var masterUser = await UserManager
           .FindByNameAsync("Berkas");

        var userId = masterUser!.Id;

        var filePath = "Resources/documents-seed-test.json";

        var command = new SeedDocumentCommand(filePath, userId);

        // Act
        await Handler
           .Handle(command, CancellationToken.None);

        // Assert
        var expected = new[]
        {
            new Document
            {
                Name = "Устав образовательной организации",
                Description = "sbabab",
                DownloadUrl = new Uri("https://www.spbstu.ru/upload/administration-catalogue/ustav-18-03-21.pdf"),
                CreatedById = userId
            },
            new Document
            {
                Name = "Порядок оформления возникновения, приостановления и прекращения отношений с Политехом",
                Description = "Порядок оформления возникновения, приостановления и прекращения отношений",
                DownloadUrl = new Uri("https://www.spbstu.ru/upload/sveden/Otnoshenie_spbpu_2018.pdf"),
                CreatedById = userId
            },
            new Document
            {
                Name = "Правила внутреннего трудового распорядка",
                Description = "Правила трудового распорядка",
                DownloadUrl =
                    new Uri("https://www.spbstu.ru/upload/sveden/pravila_trud_rasporyadka_2023_signature.pdf"),
                CreatedById = userId
            }
        };

        var createdDocuments = Context
           .Documents
           .Select(x => new
            {
                x.Name,
                x.Description,
                x.DownloadUrl,
                x.CreatedById
            })
           .ToList();

        createdDocuments
           .Should()
           .BeEquivalentTo(
                expected,
                o => o.ExcludingMissingMembers());
    }
}