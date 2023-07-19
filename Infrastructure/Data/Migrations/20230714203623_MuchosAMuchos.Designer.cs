﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(SistemReporteContext))]
    [Migration("20230714203623_MuchosAMuchos")]
    partial class MuchosAMuchos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Area", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Categoria", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("TipoEmail")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Email");
                });

            modelBuilder.Entity("Core.Entities.EmailTrainer", b =>
                {
                    b.Property<int>("EmailId")
                        .HasColumnType("int");

                    b.Property<int>("TrainerId")
                        .HasColumnType("int");

                    b.Property<string>("DireccionEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<int?>("EmailId1")
                        .HasColumnType("int");

                    b.Property<int?>("TrainerId1")
                        .HasColumnType("int");

                    b.HasKey("EmailId", "TrainerId");

                    b.HasIndex("EmailId1");

                    b.HasIndex("TrainerId");

                    b.HasIndex("TrainerId1");

                    b.ToTable("EmailTrainer", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Hardware", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar");

                    b.Property<int>("PuestoId")
                        .HasColumnType("int");

                    b.Property<int>("TipoHardwareId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("PuestoId");

                    b.HasIndex("TipoHardwareId");

                    b.ToTable("Hardware", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Lugar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdArea")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<int>("NroPuestos")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdArea");

                    b.ToTable("Lugar", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Puesto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdLugar")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdLugar");

                    b.ToTable("Puesto", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Software", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(120)
                        .HasColumnType("varchar");

                    b.Property<int>("PuestoId")
                        .HasColumnType("int");

                    b.Property<int>("TipoSoftwareId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("PuestoId");

                    b.HasIndex("TipoSoftwareId");

                    b.ToTable("Software", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TipoHardware", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("TipoHardware", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TipoSoftware", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("TipoSoftWare", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Trainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Trainer", (string)null);
                });

            modelBuilder.Entity("Core.Entities.EmailTrainer", b =>
                {
                    b.HasOne("Core.Entities.Email", "Email")
                        .WithMany()
                        .HasForeignKey("EmailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Email", null)
                        .WithMany("EmailTrainers")
                        .HasForeignKey("EmailId1");

                    b.HasOne("Core.Entities.Trainer", "Trainer")
                        .WithMany()
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Trainer", null)
                        .WithMany("EmailTrainers")
                        .HasForeignKey("TrainerId1");

                    b.Navigation("Email");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("Core.Entities.Hardware", b =>
                {
                    b.HasOne("Core.Entities.Categoria", "Categoria")
                        .WithMany("Hardwares")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Puesto", "Puesto")
                        .WithMany("Hardwares")
                        .HasForeignKey("PuestoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoHardware", "TipoHardware")
                        .WithMany("Hardwares")
                        .HasForeignKey("TipoHardwareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Puesto");

                    b.Navigation("TipoHardware");
                });

            modelBuilder.Entity("Core.Entities.Lugar", b =>
                {
                    b.HasOne("Core.Entities.Area", "Area")
                        .WithMany("Lugares")
                        .HasForeignKey("IdArea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("Core.Entities.Puesto", b =>
                {
                    b.HasOne("Core.Entities.Lugar", "Lugar")
                        .WithMany("Puestos")
                        .HasForeignKey("IdLugar")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lugar");
                });

            modelBuilder.Entity("Core.Entities.Software", b =>
                {
                    b.HasOne("Core.Entities.Categoria", "Categoria")
                        .WithMany("Softwares")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Puesto", "Puesto")
                        .WithMany("Softwares")
                        .HasForeignKey("PuestoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoSoftware", "TipoSoftware")
                        .WithMany("Softwares")
                        .HasForeignKey("TipoSoftwareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Puesto");

                    b.Navigation("TipoSoftware");
                });

            modelBuilder.Entity("Core.Entities.Area", b =>
                {
                    b.Navigation("Lugares");
                });

            modelBuilder.Entity("Core.Entities.Categoria", b =>
                {
                    b.Navigation("Hardwares");

                    b.Navigation("Softwares");
                });

            modelBuilder.Entity("Core.Entities.Email", b =>
                {
                    b.Navigation("EmailTrainers");
                });

            modelBuilder.Entity("Core.Entities.Lugar", b =>
                {
                    b.Navigation("Puestos");
                });

            modelBuilder.Entity("Core.Entities.Puesto", b =>
                {
                    b.Navigation("Hardwares");

                    b.Navigation("Softwares");
                });

            modelBuilder.Entity("Core.Entities.TipoHardware", b =>
                {
                    b.Navigation("Hardwares");
                });

            modelBuilder.Entity("Core.Entities.TipoSoftware", b =>
                {
                    b.Navigation("Softwares");
                });

            modelBuilder.Entity("Core.Entities.Trainer", b =>
                {
                    b.Navigation("EmailTrainers");
                });
#pragma warning restore 612, 618
        }
    }
}
