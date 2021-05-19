﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokemonPC3.Models;

namespace PokemonPC3.Migrations
{
    [DbContext(typeof(PokemonContext))]
    partial class PokemonContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PokemonPC3.Models.Entrenador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PuebloId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PuebloId");

                    b.ToTable("Entrenadores");
                });

            modelBuilder.Entity("PokemonPC3.Models.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pokemones");
                });

            modelBuilder.Entity("PokemonPC3.Models.Pueblo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Pueblos");
                });

            modelBuilder.Entity("PokemonPC3.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regiones");
                });

            modelBuilder.Entity("PokemonPC3.Models.Tipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tipo");
                });

            modelBuilder.Entity("PokemonTipo", b =>
                {
                    b.Property<int>("PokemonesId")
                        .HasColumnType("int");

                    b.Property<int>("TiposId")
                        .HasColumnType("int");

                    b.HasKey("PokemonesId", "TiposId");

                    b.HasIndex("TiposId");

                    b.ToTable("PokemonTipo");
                });

            modelBuilder.Entity("PokemonPC3.Models.Entrenador", b =>
                {
                    b.HasOne("PokemonPC3.Models.Pueblo", "Pueblo")
                        .WithMany("Entrenadores")
                        .HasForeignKey("PuebloId");

                    b.Navigation("Pueblo");
                });

            modelBuilder.Entity("PokemonPC3.Models.Pueblo", b =>
                {
                    b.HasOne("PokemonPC3.Models.Region", "Region")
                        .WithMany("Pueblos")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("PokemonTipo", b =>
                {
                    b.HasOne("PokemonPC3.Models.Pokemon", null)
                        .WithMany()
                        .HasForeignKey("PokemonesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokemonPC3.Models.Tipo", null)
                        .WithMany()
                        .HasForeignKey("TiposId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PokemonPC3.Models.Pueblo", b =>
                {
                    b.Navigation("Entrenadores");
                });

            modelBuilder.Entity("PokemonPC3.Models.Region", b =>
                {
                    b.Navigation("Pueblos");
                });
#pragma warning restore 612, 618
        }
    }
}
