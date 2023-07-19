using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class LugarConfiguration : IEntityTypeConfiguration<Lugar> {

    public void Configure(EntityTypeBuilder<Lugar> builder ){

        builder.ToTable("Lugar");

        builder.HasOne(l => l.Area)
       .WithMany(a => a.Lugares)
       .HasForeignKey(l => l.IdArea);

       builder.Property(n => n.Nombre)
       .HasColumnType("varchar")
       .HasMaxLength(50)
       .IsRequired();

       builder.Property(n => n.NroPuestos)
       .HasMaxLength(4)
       .IsRequired();

    }
}