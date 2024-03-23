using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlySpans.PolyLeads.Api.Data.Entities;

public class ChildGroupConfiguration : IEntityTypeConfiguration<ChildGroup>
{
    public void Configure(EntityTypeBuilder<ChildGroup> builder)
    {
        builder
           .HasKey(x => new
            {
                x.ParentGroupId,
                x.ChildGroupId
            });
    }
}
