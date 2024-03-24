using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlySpans.PolyLeads.Api.Data.Entities;

public sealed class DocumentInGroupConfiguration : IEntityTypeConfiguration<DocumentInGroup>
{
    public void Configure(EntityTypeBuilder<DocumentInGroup> builder)
    {
        builder
           .HasKey(x => new
            {
                x.DocumentId,
                x.DocumentGroupId
            });
    }
}
