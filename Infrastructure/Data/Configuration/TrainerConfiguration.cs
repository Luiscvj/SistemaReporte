using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Entities;

public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
{
    public void Configure(EntityTypeBuilder<Trainer> builder)
    {
         builder.ToTable("Trainer");

         builder.HasMany(t=> t.Emails)
         .WithMany(e => e.Trainers)
         .UsingEntity<EmailTrainer>();
         

      /*       
        j => j
                .HasOne(et => et.Email)
                .WithMany()
                .HasForeignKey(et=> et.EmailId),
         j => j
            .HasOne(typeof(Email))
            .WithMany()
            .HasForeignKey("TrainerId")
            .HasPrincipalKey(nameof(Trainer.Id));

         j => {
                j.ToTable("EmailTrainer");
                j.HasKey(et => new {et.EmailId,et.TrainerId});
              }); */

        

        
    }
}