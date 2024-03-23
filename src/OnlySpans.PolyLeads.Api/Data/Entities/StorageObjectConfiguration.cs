using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlySpans.PolyLeads.Api.Data.Entities;

public class StorageObjectConfiguration : IEntityTypeConfiguration<StorageObject>
{
    public void Configure(EntityTypeBuilder<StorageObject> builder)
    {
        builder
           .HasKey(x => x.Id);

        builder
           .Property(x => x.StorageAlias)
           .HasMaxLength(64);

        builder
           .Property(x => x.StorageId)
           .HasMaxLength(64);

        builder
           .HasOne(x => x.FileEntry)
           .WithOne()
           .HasForeignKey<FileEntry>(x => x.StorageObjectId);
    }
}
