using System.Security.Cryptography.X509Certificates;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class EmailTrainerConfiguration : IEntityTypeConfiguration<EmailTrainer>
{
    public void Configure(EntityTypeBuilder<EmailTrainer> builder)
    {
       builder.ToTable("EmailTrainer");
     
    }
}