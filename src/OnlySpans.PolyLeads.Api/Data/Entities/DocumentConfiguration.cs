using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlySpans.PolyLeads.Api.Data.Entities;

public sealed class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder
           .Property(x => x.Name)
           .HasMaxLength(128);

        builder
           .Property(x => x.Description)
           .HasMaxLength(512);
    }
}
