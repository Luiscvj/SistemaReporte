using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class HradwareConfiguration : IEntityTypeConfiguration<Hardware> {

    public void Configure(EntityTypeBuilder<Hardware> builder){

        builder.ToTable("Hardware");

        builder.HasOne(h => h.TipoHardware)
        .WithMany(t => t.Hardwares)
        .HasForeignKey(h => h.TipoHardwareId);

        builder.HasOne(h => h.Puesto)
        .WithMany(p => p.Hardwares)
        .HasForeignKey(h => h.PuestoId);

        builder.HasOne(h => h.Categoria)
        .WithMany(c => c.Hardwares)
        .HasForeignKey( h => h.CategoriaId);

        builder.Property(h => h.Descripcion)
        .HasColumnType("varchar")
        .HasMaxLength(120)
        .IsRequired();


    }
}