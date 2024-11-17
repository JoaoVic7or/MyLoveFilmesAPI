using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Infra.Configuration
{
    public class WatchListConfiguration : IEntityTypeConfiguration<WatchList>
    {
        public void Configure(EntityTypeBuilder<WatchList> builder)
        {
            builder.ToTable("tb_watch_later");

            builder.HasKey(x => new { x.MovieId, x.UserId });

            builder.Property(x => x.UserId)
                   .HasColumnName("userid")
                   .IsRequired();

            builder.Property(x => x.MovieId)
                   .HasColumnName("movieid")
                   .IsRequired();

            builder.HasOne(x => x.Movie)
                   .WithMany(x => x.WatchLists)
                   .HasForeignKey(x => x.MovieId);

            builder.HasOne(x => x.User)
                   .WithMany(x => x.WatchLists)
                   .HasForeignKey(x => x.UserId);
        }
    }
}
