using Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class FruitConfiguration
    {
        public void Configure(EntityTypeBuilder<Fruit> builder)
        {
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Description)
                .IsRequired();


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
