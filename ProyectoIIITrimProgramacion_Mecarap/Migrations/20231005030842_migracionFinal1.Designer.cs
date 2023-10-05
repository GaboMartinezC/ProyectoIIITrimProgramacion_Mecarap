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
    [Migration("20231005030842_migracionFinal1")]
    partial class migracionFinal1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

            modelBuilder.Entity("ProyectoIIITrimProgramacion_Mecarap.Models.Observacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdObservacion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdObservacion");

                    b.ToTable("Progresos");
                });

            modelBuilder.Entity("ProyectoIIITrimProgramacion_Mecarap.Models.TipoAuto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("ProyectoIIITrimProgramacion_Mecarap.Models.Usuario", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("IdAuto")
                        .HasColumnType("int");

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

                    b.HasIndex("IdAuto");

                    b.HasIndex("IdTipoUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ProyectoIIITrimProgramacion_Mecarap.Models.Vehiculo", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdTipoAuto")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdTipoAuto");

                    b.ToTable("Vehiculos");
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

            modelBuilder.Entity("ProyectoIIITrimProgramacion_Mecarap.Models.TipoUsuario", b =>
                {
                    b.HasOne("ProyectoIIITrimProgramacion_Mecarap.Models.Permiso", "Permiso")
                        .WithMany()
                        .HasForeignKey("IdPermiso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permiso");
                });

            modelBuilder.Entity("ProyectoIIITrimProgramacion_Mecarap.Models.Usuario", b =>
                {
                    b.HasOne("ProyectoIIITrimProgramacion_Mecarap.Models.Vehiculo", "Vehiculo")
                        .WithMany()
                        .HasForeignKey("IdAuto");

                    b.HasOne("ProyectoIIITrimProgramacion_Mecarap.Models.TipoUsuario", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("IdTipoUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoUsuario");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("ProyectoIIITrimProgramacion_Mecarap.Models.Vehiculo", b =>
                {
                    b.HasOne("ProyectoIIITrimProgramacion_Mecarap.Models.TipoAuto", "TipoAuto")
                        .WithMany()
                        .HasForeignKey("IdTipoAuto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoAuto");
                });
#pragma warning restore 612, 618
        }
    }
}
