using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Infra.Configuration
{
    public class RatingsConfiguration : IEntityTypeConfiguration<Ratings>
    {
        public void Configure(EntityTypeBuilder<Ratings> builder)
        {
            builder.ToTable("tb_movie_ratings");

            builder.HasKey(x => new { x.UserId, x.MovieId });

            builder.Property(x => x.UserId)
                   .HasColumnName("userid")
                   .IsRequired();

            builder.Property(x => x.MovieId)
                   .HasColumnName("movieid")
                   .IsRequired();

            builder.Property(x => x.Rating)
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
