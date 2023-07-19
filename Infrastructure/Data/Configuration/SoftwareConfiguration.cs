using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;


public class SoftwareConfiguration : IEntityTypeConfiguration<Software>
{
    public void Configure(EntityTypeBuilder<Software> builder)
    {
        builder.ToTable("Software");

        builder.Property(s => s.Descripcion)
        .HasColumnType("varchar")
        .HasMaxLength(120);

        builder.HasOne(s => s.TipoSoftware)
        .WithMany(t => t.Softwares)
        .HasForeignKey(s => s.TipoSoftwareId);

        builder.HasOne(s => s.Puesto)
        .WithMany(p => p.Softwares)
        .HasForeignKey(s => s.PuestoId);

        builder.HasOne(s => s.Categoria)
        .WithMany(c => c.Softwares)
        .HasForeignKey(s => s.CategoriaId);

        
    }
}