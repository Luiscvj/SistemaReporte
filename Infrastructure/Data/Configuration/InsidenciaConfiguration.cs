using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data;


public class InsidenciaConfiguration : IEntityTypeConfiguration<Insidencia>
{
    public void Configure(EntityTypeBuilder<Insidencia> builder)
    {
       builder.ToTable("Insidencias");

       builder.HasOne(i => i.TipoInsidencias)
       .WithMany(ti => ti.Insidencias)
       .HasForeignKey(i => i.TipoInsidenciaId);

       builder.HasOne(i => i.Trainers)
       .WithMany(t => t.Insidencias)
       .HasForeignKey(i => i.TrainerId);

       builder.HasOne(i => i.Puestos)
       .WithMany(P => P.Insidencias)
       .HasForeignKey(i => i.PuestoId);

       builder.HasOne(i => i.Categorias)
       .WithMany(c => c.Insidencias)
       .HasForeignKey(i => i.CategoriaId);

       builder.Property(i => i.Descripcion)
       .HasMaxLength(200)
       .IsRequired();



    }
}