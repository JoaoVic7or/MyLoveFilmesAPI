using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Infra.Configuration
{
    public class PosterConfiguration : IEntityTypeConfiguration<Poster>
    {
        public void Configure(EntityTypeBuilder<Poster> builder)
        {
            builder.ToTable("tb_movie_poster");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("posterid")
                   .IsRequired();

            builder.Property(x => x.MovieId)
                   .HasColumnName("movieid")
                   .IsRequired();

            builder.Property(x => x.Image)
                   .HasColumnName("image")
                   .IsRequired();

            builder.HasOne(x => x.Movie)
                   .WithOne(x => x.Poster)
                   .HasForeignKey<Poster>(x => x.MovieId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
