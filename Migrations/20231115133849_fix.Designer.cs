﻿// <auto-generated />
using System;
using BookStoreMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStoreMVC.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20231115133849_fix")]
    partial class fix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookStoreMVC.Models.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Autor");
                });

            modelBuilder.Entity("BookStoreMVC.Models.Editorial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Editorial");
                });

            modelBuilder.Entity("BookStoreMVC.Models.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genero");
                });

            modelBuilder.Entity("BookStoreMVC.Models.Libro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AutorRefId")
                        .HasColumnType("int");

                    b.Property<int?>("EditorialRefId")
                        .HasColumnType("int");

                    b.Property<int?>("GeneroRefId")
                        .HasColumnType("int");

                    b.Property<string>("ImagenLibro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NroPaginas")
                        .HasColumnType("int");

                    b.Property<int?>("Precio")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AutorRefId");

                    b.HasIndex("EditorialRefId");

                    b.HasIndex("GeneroRefId");

                    b.ToTable("Libro");
                });

            modelBuilder.Entity("BookStoreMVC.Models.Libro", b =>
                {
                    b.HasOne("BookStoreMVC.Models.Autor", "Autor")
                        .WithMany()
                        .HasForeignKey("AutorRefId");

                    b.HasOne("BookStoreMVC.Models.Editorial", "Editorial")
                        .WithMany()
                        .HasForeignKey("EditorialRefId");

                    b.HasOne("BookStoreMVC.Models.Genero", "Genero")
                        .WithMany()
                        .HasForeignKey("GeneroRefId");

                    b.Navigation("Autor");

                    b.Navigation("Editorial");

                    b.Navigation("Genero");
                });
#pragma warning restore 612, 618
        }
    }
}
