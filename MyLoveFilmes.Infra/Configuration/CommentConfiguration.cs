using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Infra.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("tb_users_comments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("commentid")
                   .IsRequired();

            builder.Property(x => x.UserId)
                   .HasColumnName("userid")
                   .IsRequired();

            builder.Property(x => x.MovieId)
                   .HasColumnName("movieid")
                   .IsRequired();

            builder.Property(x => x.CommentText)
                   .HasColumnName("comment");

            builder.Property(x => x.Date)
                   .HasColumnName("date")
                   .IsRequired();

            builder.HasOne(x => x.User)
                   .WithMany(u => u.Comments)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Movie)
                   .WithMany(m => m.Comments)
                   .HasForeignKey(x => x.MovieId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
