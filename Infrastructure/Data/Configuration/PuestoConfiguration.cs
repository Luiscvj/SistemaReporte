using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class PuestoConfiguration :IEntityTypeConfiguration<Puesto> {

    public void Configure(EntityTypeBuilder<Puesto> builder ){

        builder.ToTable("Puesto");

        builder.HasOne(p =>p.Lugar)
        .WithMany(l=>l.Puestos)
        .HasForeignKey(p => p.IdLugar);

        
    }
}