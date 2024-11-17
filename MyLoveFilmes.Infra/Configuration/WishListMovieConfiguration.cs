using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Infra.Configuration
{
    public class WishListMovieConfiguration : IEntityTypeConfiguration<WishListMovie>
    {
        public void Configure(EntityTypeBuilder<WishListMovie> builder)
        {
            builder.ToTable("tb_wish_list");

            builder.HasKey(x => new { x.MovieId, x.UserId });

            builder.Property(x => x.MovieId)
                   .HasColumnName("movieid")
                   .IsRequired();

            builder.Property(x => x.UserId)
                   .HasColumnName("userid")
                   .IsRequired();

            builder.HasOne(x => x.Movie)
                   .WithMany(x => x.WishListMovies)
                   .HasForeignKey(x => x.MovieId);

            builder.HasOne(x => x.User)
                   .WithMany(x => x.WishListMovies)
                   .HasForeignKey(x => x.UserId);
        }
    }
}
