using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Infra.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("tb_users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("Id")
                   .IsRequired();

            builder.Property(x => x.Name)
                   .HasColumnName("Name")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Email)
                   .HasColumnName("Email")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.RoleId)
                   .HasColumnName("RoleId")
                   .IsRequired();

            builder.Property(x => x.Password)
                   .HasColumnName("Password")
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(x => x.ProfilePicture)
                   .HasColumnName("image");
                   
            builder.HasOne(x => x.Roles)
                   .WithMany(x => x.Users)
                   .HasForeignKey(x => x.RoleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
