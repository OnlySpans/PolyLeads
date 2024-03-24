using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlySpans.PolyLeads.Api.Data.Entities;

public sealed class RecognitionResultConfiguration : IEntityTypeConfiguration<RecognitionResult>
{
    public void Configure(EntityTypeBuilder<RecognitionResult> builder)
    {
        builder
           .Property(x => x.AllText)
           .HasMaxLength(65536);
    }
}
