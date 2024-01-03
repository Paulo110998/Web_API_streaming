﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _2._web_API.Data;

#nullable disable

namespace _2._web_API.Migrations.Series
{
    [DbContext(typeof(SeriesContext))]
    [Migration("20240102174037_Series")]
    partial class Series
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("_2._web_API.Models.Series", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Episodios")
                        .HasColumnType("int");

                    b.Property<byte[]>("ImagemSerie")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("Sinopse")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Temporadas")
                        .HasColumnType("int");

                    b.Property<string>("TituloSerie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Seriess");
                });
#pragma warning restore 612, 618
        }
    }
}
