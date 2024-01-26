using Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class CharacterConfiguration
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.Property(a => a.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Age)
                .IsRequired();

            builder.Property(a => a.Origin)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Reward)
              .IsRequired();

            builder.Property(a => a.Height)
             .IsRequired();

            builder.Property(a => a.PirateId)
            .IsRequired();

            builder.HasOne(p => p.Pirate)
                .WithMany(p => p.Members);


            builder.Property(a => a.ImageURL)
                .IsRequired();

            builder.Property(a => a.Created)
                .HasColumnType("SMALLDATETIME");

            builder.Property(a => a.LastModified)
                .HasColumnType("SMALLDATETIME");

            builder.Property(a => a.Deleted)
                .HasColumnType("SMALLDATETIME");
        }
    }
}
