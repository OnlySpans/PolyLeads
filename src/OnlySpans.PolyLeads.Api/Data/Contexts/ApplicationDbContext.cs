using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlySpans.PolyLeads.Api.Data.Entities;

namespace OnlySpans.PolyLeads.Api.Data.Contexts;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationUserRole, Guid>
{
    public DbSet<StorageObject> StorageObjects { get; init; } = default!;

    public DbSet<FileRecognitionStatus> FileRecognitionStatuses { get; init; } = default!;

    public DbSet<RecognitionResult> RecognitionResults { get; init; } = default!;

    public DbSet<FileEntry> FileEntries { get; init; } = default!;

    public DbSet<Document> Documents { get; init; } = default!;

    public DbSet<DocumentInGroup> DocumentInGroups { get; init; } = default!;

    public DbSet<DocumentGroup> DocumentGroups { get; init; } = default!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
           .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
