﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoIIITrimProgramacion_Mecarap.Datos;

#nullable disable

namespace ProyectoIIITrimProgramacion_Mecarap.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231016042509_borrado")]
    partial class borrado
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProyectoIIITrimProgramacion_Mecarap.Models.Cliente", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<bool?>("Borrado")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ProyectoIIITrimProgramacion_Mecarap.Models.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("ProyectoIIITrimProgramacion_Mecarap.Models.HojaIngreso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Borrado")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fecha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observaciones")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HojasIngreso");
                });

            modelBuilder.Entity("ProyectoIIITrimProgramacion_Mecarap.Models.InformeFinal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InformesFinal");
                });

            modelBuilder.Entity("ProyectoIIITrimProgramacion_Mecarap.Models.Mecanico", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<bool?>("Borrado")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<int?>("IdTipoUsuario")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdTipoUsuario");

                    b.ToTable("Mecanicos");
                });

            modelBuilder.Entity("ProyectoIIITrimProgramacion_Mecarap.Models.Observacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Borrado")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fecha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Observaciones");
                });

            modelBuilder.Entity("ProyectoIIITrimProgramacion_Mecarap.Models.Permiso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permisos");
                });

            modelBuilder.Entity("ProyectoIIITrimProgramacion_Mecarap.Models.Progreso", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<bool?>("Borrado")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdObservacion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdObservacion");

                    b.ToTable("Progresos");
                });

            modelBuilder.Entity("ProyectoIIITrimProgramacion_Mecarap.Models.Reparacion", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("FechaSolicitada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdAuto")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("IdEstado")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("IdHojaIngreso")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("IdInforme")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("IdMecanico")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("IdProgreso")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdAuto");

                    b.HasIndex("IdEstado");

                    b.HasIndex("IdHojaIngreso");

                    b.HasIndex("IdInforme");

                    b.HasIndex("IdMecanico");

                    b.HasIndex("IdProgreso");

                    b.ToTable("Reparaciones");
                });

            modelBuilder.Entity("ProyectoIIITrimProgramacion_Mecarap.Models.TipoAuto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Borrado")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TiposAuto");
                });

            modelBuilder.Entity("ProyectoIIITrimProgramacion_Mecarap.Models.TipoUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Borrado")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdPermiso")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPermiso");

                    b.ToTable("TiposUsuario");
                });

            modelBuilder.Entity("ProyectoIIITrimProgramacion_Mecarap.Models.Vehiculo", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<bool?>("Borrado")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPropietario")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoAuto")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdPropietario");

                    b.HasIndex("IdTipoAuto");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("ProyectoIIITrimProgramacion_Mecarap.Models.Mecanico", b =>
                {
                    b.HasOne("ProyectoIIITrimProgramacion_Mecarap.Models.TipoUsuario", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("IdTipoUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoUsuario");
                });

            modelBuilder.Entity("ProyectoIIITrimProgramacion_Mecarap.Models.Progreso", b =>
                {
                    b.HasOne("ProyectoIIITrimProgramacion_Mecarap.Models.Observacion", "Observacion")
                        .WithMany()
                        .HasForeignKey("IdObservacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Observacion");
                });

            modelBuilder.Entity("ProyectoIIITrimProgramacion_Mecarap.Models.Reparacion", b =>
                {
                    b.HasOne("ProyectoIIITrimProgramacion_Mecarap.Models.Vehiculo", "Vehiculo")
                        .WithMany()
                        .HasForeignKey("IdAuto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIIITrimProgramacion_Mecarap.Models.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIIITrimProgramacion_Mecarap.Models.HojaIngreso", "HojaIngreso")
                        .WithMany()
                        .HasForeignKey("IdHojaIngreso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIIITrimProgramacion_Mecarap.Models.InformeFinal", "InformeFinal")
                        .WithMany()
                        .HasForeignKey("IdInforme")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIIITrimProgramacion_Mecarap.Models.Mecanico", "Mecanico")
                        .WithMany()
                        .HasForeignKey("IdMecanico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIIITrimProgramacion_Mecarap.Models.Progreso", "Progreso")
                        .WithMany()
                        .HasForeignKey("IdProgreso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");

                    b.Navigation("HojaIngreso");

                    b.Navigation("InformeFinal");

                    b.Navigation("Mecanico");

                    b.Navigation("Progreso");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("ProyectoIIITrimProgramacion_Mecarap.Models.TipoUsuario", b =>
                {
                    b.HasOne("ProyectoIIITrimProgramacion_Mecarap.Models.Permiso", "Permiso")
                        .WithMany()
                        .HasForeignKey("IdPermiso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permiso");
                });

            modelBuilder.Entity("ProyectoIIITrimProgramacion_Mecarap.Models.Vehiculo", b =>
                {
                    b.HasOne("ProyectoIIITrimProgramacion_Mecarap.Models.Cliente", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdPropietario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIIITrimProgramacion_Mecarap.Models.TipoAuto", "TipoAuto")
                        .WithMany()
                        .HasForeignKey("IdTipoAuto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoAuto");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
