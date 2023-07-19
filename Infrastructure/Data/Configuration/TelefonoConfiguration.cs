using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Entities;


public class TelefonoConfiguration : IEntityTypeConfiguration<Telefono> {

    public void Configure(EntityTypeBuilder<Telefono> builder){

        builder.ToTable("Telefono");

        builder.HasMany(t => t.Trainers)
        .WithMany(tr => tr.Telefonos)
        .UsingEntity<TelefonoTrainer>(
            j => j.Property(tt=>tt.Telefono)
            .HasColumnType("varchar")
            .HasMaxLength(15)
            .IsRequired()
        );
    }
}