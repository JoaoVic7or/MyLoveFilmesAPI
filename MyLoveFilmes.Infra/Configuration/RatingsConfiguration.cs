using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Infra.Configuration
{
    public class RatingsConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("tb_movie_ratings");

            builder.HasKey(x => new { x.UserId, x.MovieId });

            builder.Property(x => x.UserId)
                   .HasColumnName("userid")
                   .IsRequired();

            builder.Property(x => x.MovieId)
                   .HasColumnName("movieid")
                   .IsRequired();

            builder.Property(x => x.RatingValue)
                   .HasColumnName("rating")
                   .IsRequired();

            builder.HasOne(x => x.User)
                   .WithMany(x => x.Ratings)
                   .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Movie)
                   .WithMany(x => x.Ratings)
                   .HasForeignKey(x => x.MovieId);
        }
    }
}
