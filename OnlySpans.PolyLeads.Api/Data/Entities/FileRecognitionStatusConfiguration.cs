using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlySpans.PolyLeads.Api.Data.Entities;

public class FileRecognitionStatusConfiguration : IEntityTypeConfiguration<FileRecognitionStatus>
{
    public void Configure(EntityTypeBuilder<FileRecognitionStatus> builder)
    {
        builder
           .HasKey(x => x.Id);
    }
}
