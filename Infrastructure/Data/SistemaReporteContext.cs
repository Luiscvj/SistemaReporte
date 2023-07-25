using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class SistemReporteContext : DbContext {

    public SistemReporteContext(DbContextOptions<SistemReporteContext> options ): base(options){



    }


    public DbSet<Area> ? Areas {get;set;}
    public DbSet<Categoria> ? Categorias {get;set;}
    public DbSet<Hardware> ? Hardwares {get;set;}
    public DbSet<Lugar> ? Lugares {get;set;}
    public DbSet<Puesto> ? Puestos {get;set;}
    public DbSet<Software> ? Softwares {get;set;}
    public DbSet<TipoHardware> ? TipoHardwares {get;set;}
    public DbSet<TipoSoftware> ? TipoSoftwares {get;set;}
    public DbSet<Trainer> ? Trainers {get;set;} 
    public DbSet<Telefono> ? Telefonos {get;set;} 
    public DbSet<Insidencia> ? Insidencias {get;set;}
    public DbSet<TipoInsidencia> ? TipoInsidencias {get;set;}
    public DbSet<Email> ? Emails {get;set;}
    public DbSet<EmailTrainer> ? EmailTrainers {get;set;}
   
    



    
     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//Me aplica las configuraciones adicionales de mis entidades dentro de mi ensamblaje, y busca todoas las clases 
        //que hereden De IEtityTypeConfiguration y las aplica
    }

}