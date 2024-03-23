using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlySpans.PolyLeads.Api.Data.Entities;

public class RecognitionResultConfiguration : IEntityTypeConfiguration<RecognitionResult>
{
    public void Configure(EntityTypeBuilder<RecognitionResult> builder)
    {
        builder
           .HasKey(x => x.Id);
        
        builder
           .Property(x => x.AllText)
           .HasMaxLength(65536);
    }
}
