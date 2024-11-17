using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Infra.Configuration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("tb_genres");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("Id")
                   .IsRequired();

            builder.Property(x => x.Name)
                   .HasColumnName("Name")
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
