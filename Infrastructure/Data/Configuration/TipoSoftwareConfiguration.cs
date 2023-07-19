using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class TipoSoftwareConfiguration : IEntityTypeConfiguration<TipoSoftware> {

    public void Configure(EntityTypeBuilder<TipoSoftware> builder){

        builder.ToTable("TipoSoftWare");
        
        builder.Property(t => t.Nombre)
        .HasColumnType("varchar")
        .HasMaxLength(120)
        .IsRequired();


    }
}