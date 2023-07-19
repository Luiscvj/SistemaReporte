using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data;

public class TipoInsidenciaConfiguration : IEntityTypeConfiguration<TipoInsidencia>
{
    public void Configure(EntityTypeBuilder<TipoInsidencia> builder)
    {
        builder.ToTable("Tipo Insidencia");

        builder.Property(ti => ti.NombreNivel)
        .HasColumnName("Nivel de Insidencia")
        .HasMaxLength(30);
    }
}

