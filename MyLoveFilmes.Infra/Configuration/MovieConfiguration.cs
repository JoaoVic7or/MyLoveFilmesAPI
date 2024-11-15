using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Infra.Configuration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("tb_movies");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(x => x.Name)
                   .HasColumnName("name")
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(x => x.Synopsis)
                   .HasColumnName("synopsis");

            builder.Property(x => x.Director)
                   .HasColumnName("director");

            builder.Property(x => x.ReleaseYear)
                   .HasColumnName("releaseyear");

            builder.HasMany(x => x.MovieGenres)
                   .WithOne(x => x.Movie)
                   .HasForeignKey(x => x.MovieId);
        }
    }
}
