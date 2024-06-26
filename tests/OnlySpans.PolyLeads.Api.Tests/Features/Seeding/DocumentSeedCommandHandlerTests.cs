using Microsoft.EntityFrameworkCore;
using OnlySpans.PolyLeads.Api.Data.Entities;
using OnlySpans.PolyLeads.Api.Features.Seeding;
using OnlySpans.PolyLeads.Api.Tests.Tools;

namespace OnlySpans.PolyLeads.Api.Tests.Features.Seeding;

public sealed class DocumentSeedCommandHandlerTests : DatabaseTests
{
    private DocumentSeedCommandHandler Handler { get; set; } = default!;

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

        var command = new DocumentSeedCommand
        {
            FilePath =
                "Resources/documents-seed-test.json",
            Id = userId
        };

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
}