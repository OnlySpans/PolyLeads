using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlySpans.PolyLeads.Api.Data.Entities;

public sealed class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder
           .Property(x => x.FirstName)
           .HasMaxLength(32);

        builder
           .Property(x => x.LastName)
           .HasMaxLength(32);

        builder
           .Property(x => x.Patronymic)
           .HasMaxLength(32);
    }
}