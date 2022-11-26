﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PRutCun.Context;

namespace PRutCun.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221124012441_rutcun")]
    partial class rutcun
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PRutCun.Models.Calle", b =>
                {
                    b.Property<int>("PkCalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkCalle");

                    b.ToTable("Calle");
                });

            modelBuilder.Entity("PRutCun.Models.CalleTransitada", b =>
                {
                    b.Property<int>("FkCalle")
                        .HasColumnType("int");

                    b.Property<int>("FkTrasporte")
                        .HasColumnType("int");

                    b.HasKey("FkCalle", "FkTrasporte");

                    b.HasIndex("FkTrasporte");

                    b.ToTable("CalleTransitada");
                });

            modelBuilder.Entity("PRutCun.Models.PuntoInteres", b =>
                {
                    b.Property<int>("PkPunto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Coordenadas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkPunto");

                    b.ToTable("PuntoInteres");
                });

            modelBuilder.Entity("PRutCun.Models.PuntoTransitado", b =>
                {
                    b.Property<int>("FkPunto")
                        .HasColumnType("int");

                    b.Property<int>("FkTrasporte")
                        .HasColumnType("int");

                    b.HasKey("FkPunto", "FkTrasporte");

                    b.HasIndex("FkTrasporte");

                    b.ToTable("PuntoTransitado");
                });

            modelBuilder.Entity("PRutCun.Models.Rol", b =>
                {
                    b.Property<int>("PkRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkRol");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("PRutCun.Models.TipoTrasporte", b =>
                {
                    b.Property<int>("PkTipo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkTipo");

                    b.ToTable("TipoTrasporte");
                });

            modelBuilder.Entity("PRutCun.Models.Trasporte", b =>
                {
                    b.Property<int>("PkTrasporte")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Dia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estatus")
                        .HasColumnType("bit");

                    b.Property<int?>("FkTipo")
                        .HasColumnType("int");

                    b.Property<string>("HoraFinal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoraInicial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkTrasporte");

                    b.HasIndex("FkTipo");

                    b.ToTable("Trasporte");
                });

            modelBuilder.Entity("PRutCun.Models.Usuario", b =>
                {
                    b.Property<int>("PkUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FkRol")
                        .HasColumnType("int");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkUser");

                    b.HasIndex("FkRol");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("PRutCun.Models.CalleTransitada", b =>
                {
                    b.HasOne("PRutCun.Models.Calle", "Calle")
                        .WithMany()
                        .HasForeignKey("FkCalle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PRutCun.Models.Trasporte", "Trasporte")
                        .WithMany()
                        .HasForeignKey("FkTrasporte")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calle");

                    b.Navigation("Trasporte");
                });

            modelBuilder.Entity("PRutCun.Models.PuntoTransitado", b =>
                {
                    b.HasOne("PRutCun.Models.PuntoInteres", "Punto")
                        .WithMany()
                        .HasForeignKey("FkPunto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PRutCun.Models.Trasporte", "Trasporte")
                        .WithMany()
                        .HasForeignKey("FkTrasporte")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Punto");

                    b.Navigation("Trasporte");
                });

            modelBuilder.Entity("PRutCun.Models.Trasporte", b =>
                {
                    b.HasOne("PRutCun.Models.TipoTrasporte", "Tipo")
                        .WithMany()
                        .HasForeignKey("FkTipo");

                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("PRutCun.Models.Usuario", b =>
                {
                    b.HasOne("PRutCun.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("FkRol");

                    b.Navigation("Rol");
                });
#pragma warning restore 612, 618
        }
    }
}
