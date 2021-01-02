﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Podaci;

namespace Podaci.Migrations
{
    [DbContext(typeof(MojDbContext))]
    [Migration("20201225130250_linija")]
    partial class linija
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Podaci.Klase.Grad", b =>
                {
                    b.Property<int>("GradID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrzavaID")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GradID");

                    b.HasIndex("DrzavaID");

                    b.ToTable("Grad");
                });

            modelBuilder.Entity("Podaci.Klase.Linija", b =>
                {
                    b.Property<int>("LinijaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("CijenaJednosmijerna")
                        .HasColumnType("real");

                    b.Property<float>("CijenaPovratna")
                        .HasColumnType("real");

                    b.Property<int>("GDolaskaID")
                        .HasColumnType("int");

                    b.Property<int>("GPolaskaID")
                        .HasColumnType("int");

                    b.Property<int?>("GradDolaskaGradID")
                        .HasColumnType("int");

                    b.Property<int?>("GradPolaskaGradID")
                        .HasColumnType("int");

                    b.Property<string>("OznakaLinije")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LinijaID");

                    b.HasIndex("GradDolaskaGradID");

                    b.HasIndex("GradPolaskaGradID");

                    b.ToTable("Linija");
                });

            modelBuilder.Entity("Podaci.Klase.Obavijest", b =>
                {
                    b.Property<int>("ObavijestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumObjave")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naslov")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ObavijestKategorijaID")
                        .HasColumnType("int");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Podnaslov")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Slika")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ObavijestID");

                    b.HasIndex("ObavijestKategorijaID");

                    b.ToTable("Obavijest");
                });

            modelBuilder.Entity("Podaci.Klase.Vozilo", b =>
                {
                    b.Property<int>("VoziloID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumZadnjegServisa")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxBrojSjedista")
                        .HasColumnType("int");

                    b.Property<string>("OznakaVozila")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistracijskiBroj")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VoziloID");

                    b.ToTable("Vozilo");
                });

            modelBuilder.Entity("WebApplication1.Drzava", b =>
                {
                    b.Property<int>("DrzavaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DrzavaID");

                    b.ToTable("Drzava");
                });

            modelBuilder.Entity("WebApplication1.ObavijestKategorija", b =>
                {
                    b.Property<int>("ObavijestKategorijaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ObavijestKategorijaID");

                    b.ToTable("ObavijestKategorija");
                });

            modelBuilder.Entity("Podaci.Klase.Grad", b =>
                {
                    b.HasOne("WebApplication1.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Podaci.Klase.Linija", b =>
                {
                    b.HasOne("Podaci.Klase.Grad", "GradDolaska")
                        .WithMany()
                        .HasForeignKey("GradDolaskaGradID");

                    b.HasOne("Podaci.Klase.Grad", "GradPolaska")
                        .WithMany()
                        .HasForeignKey("GradPolaskaGradID");
                });

            modelBuilder.Entity("Podaci.Klase.Obavijest", b =>
                {
                    b.HasOne("WebApplication1.ObavijestKategorija", "ObavijestKategorija")
                        .WithMany()
                        .HasForeignKey("ObavijestKategorijaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}