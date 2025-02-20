﻿// <auto-generated />
using ApiMatheus.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiMatheus.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250215220717_EuamoaMariahehe")]
    partial class EuamoaMariahehe
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ApiMatheus.Models.Presente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Presentes");
                });

            modelBuilder.Entity("ApiMatheus.Models.PresenteEsperado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PresentesEsperados");
                });

            modelBuilder.Entity("ApiMatheus.Models.PresenteSelecionado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Pessoa")
                        .HasColumnType("longtext");

                    b.Property<int>("PresenteEsperadoId")
                        .HasColumnType("int");

                    b.Property<int>("PresenteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PresenteEsperadoId");

                    b.HasIndex("PresenteId");

                    b.ToTable("PresentesSelecionados");
                });

            modelBuilder.Entity("ApiMatheus.Models.PresenteSelecionado", b =>
                {
                    b.HasOne("ApiMatheus.Models.PresenteEsperado", "PresenteEsperado")
                        .WithMany()
                        .HasForeignKey("PresenteEsperadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiMatheus.Models.Presente", "Presente")
                        .WithMany()
                        .HasForeignKey("PresenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Presente");

                    b.Navigation("PresenteEsperado");
                });
#pragma warning restore 612, 618
        }
    }
}
