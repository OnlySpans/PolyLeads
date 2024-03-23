using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlySpans.PolyLeads.Api.Data.Entities;

public class DocumentGroupConfiguration : IEntityTypeConfiguration<DocumentGroup>
{
    public void Configure(EntityTypeBuilder<DocumentGroup> builder)
    {
        builder
           .HasKey(x => x.Id);

        builder
           .Property(x => x.Name)
           .HasMaxLength(128);

        builder
           .Property(x => x.Description)
           .HasMaxLength(512);

        builder
           .HasMany(x => x.Groups)
           .WithMany(x => x.Groups)
           .UsingEntity<ChildGroup>();
    }
}
