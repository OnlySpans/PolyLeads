using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlySpans.PolyLeads.Api.Data.Entities;

public sealed class DocumentGroupConfiguration : IEntityTypeConfiguration<DocumentGroup>
{
    public void Configure(EntityTypeBuilder<DocumentGroup> builder)
    {
        builder
           .Property(x => x.Name)
           .HasMaxLength(128);

        builder
           .Property(x => x.Description)
           .HasMaxLength(512);

        builder
           .HasOne(x => x.ParentGroup)
           .WithMany(x => x.ChildGroups)
           .HasForeignKey(x => x.ParentGroupId)
           .IsRequired(false);
    }
}
