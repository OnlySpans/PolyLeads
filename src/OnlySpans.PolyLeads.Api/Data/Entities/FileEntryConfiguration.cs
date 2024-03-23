using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlySpans.PolyLeads.Api.Data.Entities;

public class FileEntryConfiguration : IEntityTypeConfiguration<FileEntry>
{
    public void Configure(EntityTypeBuilder<FileEntry> builder)
    {
        builder
           .HasKey(x => x.Id);

        builder
           .Property(x => x.Name)
           .HasMaxLength(128);

        builder
           .Property(x => x.Extension)
           .HasMaxLength(8);

        builder
           .HasMany(x => x.RecognitionResults)
           .WithOne(x => x.FileEntry)
           .HasForeignKey(x => x.FileEntryId);

        builder
           .HasMany(x => x.RecognitionStatuses)
           .WithOne(x => x.FileEntry)
           .HasForeignKey(x => x.FileEntryId);

        builder
           .HasOne(x => x.Document)
           .WithOne(x => x.FileEntry)
           .HasForeignKey<Document>(x => x.FileEntryId)
           .IsRequired(false);
    }
}
