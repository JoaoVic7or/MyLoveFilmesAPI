using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Infra.Configuration
{
    public class MovieGenresConfiguration : IEntityTypeConfiguration<MovieGenres>
    {
        public void Configure(EntityTypeBuilder<MovieGenres> builder)
        {
            builder.ToTable("tb_movies_genres");

            builder.HasKey(x => new { x.MovieId, x.GenreId });

            builder.Property(x => x.MovieId)
                   .HasColumnName("movie_id")
                   .IsRequired();

            builder.Property(x => x.GenreId)
                   .HasColumnName("genre_id")
                   .IsRequired();

            builder.HasOne(x => x.Movie)
                   .WithMany(x => x.MovieGenres)
                   .HasForeignKey(x => x.MovieId);

            builder.HasOne(x => x.Genre)
                   .WithMany(x => x.MovieGenres)
                   .HasForeignKey(x => x.GenreId);
        }
    }
}
