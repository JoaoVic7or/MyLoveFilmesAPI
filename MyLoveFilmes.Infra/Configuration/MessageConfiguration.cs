using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Infra.Configuration
{
	public class MessageConfiguration : IEntityTypeConfiguration<Message>
	{
		public void Configure(EntityTypeBuilder<Message> builder)
		{
			builder.ToTable("tb_messages");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				   .HasColumnName("id")
				   .IsRequired();

			builder.Property(x => x.UserId)
				   .HasColumnName("userid")
				   .IsRequired();

			builder.Property(x => x.Text)
				   .HasColumnName("message")
				   .IsRequired();

			builder.Property(x => x.Date)
				   .HasColumnName("data")
				   .IsRequired();

			builder.Property(x => x.ChatRoomId)
				   .HasColumnName("chatroomid")
				   .IsRequired();

			builder.HasOne(x => x.User)
				   .WithMany(x => x.Messages)
				   .HasForeignKey(x => x.UserId);
		}
	}
}

