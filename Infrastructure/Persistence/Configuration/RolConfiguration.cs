using Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class RolConfiguration
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Created)
                .HasColumnType("SMALLDATETIME");

            builder.Property(a => a.LastModified)
                .HasColumnType("SMALLDATETIME");

            builder.Property(a => a.Deleted)
                .HasColumnType("SMALLDATETIME");
        }
    }
}
