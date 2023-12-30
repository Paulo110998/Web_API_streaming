﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _2._web_API.Data;

#nullable disable

namespace _2._web_API.Migrations.Usuarios
{
    [DbContext(typeof(UsuariosContext))]
    [Migration("20231228034301_Planos e Perfil")]
    partial class PlanosePerfil
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("_2._web_API.Models.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NomeDoPerfil")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("PlanosId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlanosId")
                        .IsUnique();

                    b.ToTable("Perfis");
                });

            modelBuilder.Entity("_2._web_API.Models.Planos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NomePlano")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ValorPlano")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Planos");
                });

            modelBuilder.Entity("_2._web_API.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("_2._web_API.Models.Perfil", b =>
                {
                    b.HasOne("_2._web_API.Models.Planos", "Planos")
                        .WithOne("Perfil")
                        .HasForeignKey("_2._web_API.Models.Perfil", "PlanosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Planos");
                });

            modelBuilder.Entity("_2._web_API.Models.Planos", b =>
                {
                    b.Navigation("Perfil")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
