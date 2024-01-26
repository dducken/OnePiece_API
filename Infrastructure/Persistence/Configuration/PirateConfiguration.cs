using Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class PirateConfiguration
    {
        public void Configure(EntityTypeBuilder<Pirate> builder)
        {
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Ship)
             .IsRequired();

            builder.Property(a => a.TotalReward)
            .IsRequired();

            builder.Property(a => a.ImageURL)
                .IsRequired();

            builder.HasMany(p => p.Members)
                .WithOne(p => p.Pirate);

            builder.Property(a => a.Created)
                .HasColumnType("SMALLDATETIME");

            builder.Property(a => a.LastModified)
                .HasColumnType("SMALLDATETIME");

            builder.Property(a => a.Deleted)
                .HasColumnType("SMALLDATETIME");
        }
    }
}
