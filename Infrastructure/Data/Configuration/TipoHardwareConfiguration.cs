using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;


public class TipoHardwareConfiguration : IEntityTypeConfiguration<TipoHardware>
{
    public void Configure(EntityTypeBuilder<TipoHardware> builder)
    {
       builder.ToTable("TipoHardware");

       builder.Property(t => t.Nombre)
       .HasColumnType("varchar")
       .HasMaxLength(70)
       .IsRequired();
    }
}