using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlySpans.PolyLeads.Api.Data.Entities;

public sealed class PermittedSourceConfiguration : IEntityTypeConfiguration<PermittedSource>
{
    public void Configure(EntityTypeBuilder<PermittedSource> builder)
    {
        builder
           .Property(x => x.Description)
           .HasMaxLength(256);

        builder.HasData(
            new  {Id = (long) 1, BaseUrl = new Uri("https://www.spbstu.ru"), Description = "Сайт политеха"},
            new  {Id = (long) 2, BaseUrl = new Uri("https://college.spbstu.ru"), Description = "Институт среднего профессионального образования СПБПУ"},
            new  {Id = (long) 3, BaseUrl = new Uri("https://enroll.spbstu.ru"), Description = "Приемная комиссия СПБПУ"},
            new  {Id = (long) 4, BaseUrl = new Uri("https://iccs.spbstu.ru/"), Description = "ИКНК СПБПУ"},
            new  {Id = (long) 5, BaseUrl = new Uri("https://physmech.spbstu.ru/"), Description = "ФизМех СПБПУ"}
        );
    }
}