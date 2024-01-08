﻿// <auto-generated />
using System;
using Asztalfoglalas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Asztalfoglalas.Migrations
{
    [DbContext(typeof(AsztalfoglalasContext))]
    partial class AsztalfoglalasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Asztalfoglalas.Asztal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Ferohely")
                        .HasColumnType("int");

                    b.Property<string>("Megnevezes")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Asztal");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ferohely = 6,
                            Megnevezes = "1-es asztal"
                        },
                        new
                        {
                            Id = 2,
                            Ferohely = 3,
                            Megnevezes = "2-es asztal"
                        },
                        new
                        {
                            Id = 3,
                            Ferohely = 4,
                            Megnevezes = "3-es asztal"
                        },
                        new
                        {
                            Id = 4,
                            Ferohely = 5,
                            Megnevezes = "4-es asztal"
                        },
                        new
                        {
                            Id = 5,
                            Ferohely = 8,
                            Megnevezes = "5-es asztal"
                        });
                });

            modelBuilder.Entity("Asztalfoglalas.Foglalas", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AsztalID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Letszam")
                        .HasColumnType("int");

                    b.Property<string>("Nev")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefonszam")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("ID");

                    b.HasIndex("AsztalID");

                    b.ToTable("Foglalas");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AsztalID = 1,
                            Datum = new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Letszam = 3,
                            Nev = "Soós Gábor",
                            Telefonszam = "06201231234"
                        },
                        new
                        {
                            ID = 2,
                            AsztalID = 3,
                            Datum = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Letszam = 2,
                            Nev = "Nits László",
                            Telefonszam = "06201231230"
                        });
                });

            modelBuilder.Entity("Asztalfoglalas.Foglalas", b =>
                {
                    b.HasOne("Asztalfoglalas.Asztal", "Asztal")
                        .WithMany()
                        .HasForeignKey("AsztalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asztal");
                });
#pragma warning restore 612, 618
        }
    }
}
