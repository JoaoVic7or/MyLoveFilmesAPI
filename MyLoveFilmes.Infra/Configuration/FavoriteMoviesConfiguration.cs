using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Infra.Configuration
{
    public class FavoriteMoviesConfiguration : IEntityTypeConfiguration<FavoriteMovies>
    {
        public void Configure(EntityTypeBuilder<FavoriteMovies> builder)
        {
            builder.ToTable("tb_favorite_movies");

            builder.HasKey(x => new { x.MovieId, x.UserId });

            builder.Property(x => x.MovieId)
                   .HasColumnName("movieid")
                   .IsRequired();

            builder.Property(x => x.UserId)
                   .HasColumnName("userid")
                   .IsRequired();

            builder.HasOne(x => x.Movie)
                   .WithMany(x => x.FavoriteMovies)
                   .HasForeignKey(x => x.MovieId);

            builder.HasOne(x => x.User)
                   .WithMany(x => x.FavoriteMovies)
                   .HasForeignKey(x => x.UserId);
        }
    }
}
