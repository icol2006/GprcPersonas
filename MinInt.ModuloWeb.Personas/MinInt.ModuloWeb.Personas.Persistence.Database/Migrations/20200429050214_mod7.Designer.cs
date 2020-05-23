﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinInt.ModuloWeb.Personas.Persistence.Database;

namespace MinInt.ModuloWeb.Personas.Persistence.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200429050214_mod7")]
    partial class mod7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MinInt.ModuloWeb.Personas.Domain.Cambios", b =>
                {
                    b.Property<int>("ID_CAMBIO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DESCRIPCION")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("FECHA")
                        .HasColumnType("date");

                    b.Property<int>("ID_ESTADO_CAMBIO")
                        .HasColumnType("int");

                    b.Property<int>("ID_PER")
                        .HasColumnType("int");

                    b.HasKey("ID_CAMBIO");

                    b.HasIndex("ID_CAMBIO");

                    b.HasIndex("ID_ESTADO_CAMBIO");

                    b.HasIndex("ID_PER");

                    b.ToTable("CAMBIOS");
                });

            modelBuilder.Entity("MinInt.ModuloWeb.Personas.Domain.CentroCosto", b =>
                {
                    b.Property<int>("ID_CENTRO_COSTO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DESCRIPCION")
                        .HasColumnType("varchar(30)");

                    b.HasKey("ID_CENTRO_COSTO");

                    b.ToTable("CENTRO_COSTO");
                });

            modelBuilder.Entity("MinInt.ModuloWeb.Personas.Domain.EstadoCambios", b =>
                {
                    b.Property<int>("ID_ESTADO_CAMBIO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DESCRIPCION")
                        .HasColumnType("varchar(50)");

                    b.HasKey("ID_ESTADO_CAMBIO");

                    b.HasIndex("ID_ESTADO_CAMBIO");

                    b.ToTable("ESTADO_CAMBIOS");
                });

            modelBuilder.Entity("MinInt.ModuloWeb.Personas.Domain.EstadoPersona", b =>
                {
                    b.Property<int>("ID_ESTADO_PERSONA")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DESCRIPCION")
                        .HasColumnType("varchar(50)");

                    b.HasKey("ID_ESTADO_PERSONA");

                    b.HasIndex("ID_ESTADO_PERSONA");

                    b.ToTable("ESTADO_PERSONA");

                    b.HasData(
                        new
                        {
                            ID_ESTADO_PERSONA = 1,
                            DESCRIPCION = "Tipo de estado 1"
                        });
                });

            modelBuilder.Entity("MinInt.ModuloWeb.Personas.Domain.Jefaturas", b =>
                {
                    b.Property<int>("ID_JEFATURA")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ID_JEFE")
                        .HasColumnType("int");

                    b.Property<int?>("ID_SUBROGANTE")
                        .HasColumnType("int");

                    b.Property<string>("TITULO")
                        .HasColumnType("varchar(40)");

                    b.HasKey("ID_JEFATURA");

                    b.HasIndex("ID_JEFATURA");

                    b.HasIndex("ID_JEFE")
                        .IsUnique()
                        .HasFilter("[ID_JEFE] IS NOT NULL");

                    b.HasIndex("ID_SUBROGANTE")
                        .IsUnique()
                        .HasFilter("[ID_SUBROGANTE] IS NOT NULL");

                    b.ToTable("JEFATURA");

                    b.HasData(
                        new
                        {
                            ID_JEFATURA = 1,
                            ID_JEFE = 1,
                            ID_SUBROGANTE = 1,
                            TITULO = "Tipo de Jefatura 1"
                        });
                });

            modelBuilder.Entity("MinInt.ModuloWeb.Personas.Domain.Orientacion", b =>
                {
                    b.Property<int>("COD_ORIENTACION")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ORIENTACION")
                        .HasColumnType("varchar(10)");

                    b.HasKey("COD_ORIENTACION");

                    b.HasIndex("COD_ORIENTACION");

                    b.ToTable("ORIENTACION");
                });

            modelBuilder.Entity("MinInt.ModuloWeb.Personas.Domain.PermisosUsuario", b =>
                {
                    b.Property<int>("ID_PERMISOS_USUARIOS")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DESCRIPCION")
                        .HasColumnType("varchar(50)");

                    b.HasKey("ID_PERMISOS_USUARIOS");

                    b.HasIndex("ID_PERMISOS_USUARIOS");

                    b.ToTable("PERMISOS_USUARIOS");

                    b.HasData(
                        new
                        {
                            ID_PERMISOS_USUARIOS = 1,
                            DESCRIPCION = "Tipo de acceso 1"
                        },
                        new
                        {
                            ID_PERMISOS_USUARIOS = 2,
                            DESCRIPCION = "Tipo de acceso 2"
                        });
                });

            modelBuilder.Entity("MinInt.ModuloWeb.Personas.Domain.PersonaSistema", b =>
                {
                    b.Property<int>("ID_PERMISOS_SISTEMA")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DESCRIPCION")
                        .HasColumnType("varchar(50)");

                    b.HasKey("ID_PERMISOS_SISTEMA");

                    b.HasIndex("ID_PERMISOS_SISTEMA");

                    b.ToTable("PERMISOS_SISTEMAS");

                    b.HasData(
                        new
                        {
                            ID_PERMISOS_SISTEMA = 1,
                            DESCRIPCION = "Tipo de acceso 1"
                        },
                        new
                        {
                            ID_PERMISOS_SISTEMA = 2,
                            DESCRIPCION = "Tipo de acceso 2"
                        });
                });

            modelBuilder.Entity("MinInt.ModuloWeb.Personas.Domain.Personas", b =>
                {
                    b.Property<int>("ID_PER")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AP_MATERNO")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("AP_PATERNO")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("CORREO_ELECTRONICO")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("DIG_VER")
                        .HasColumnType("varchar(1)");

                    b.Property<int>("ESTADO")
                        .HasColumnType("int");

                    b.Property<int>("ID_CENTRO_COSTO")
                        .HasColumnType("int");

                    b.Property<int>("ID_ESTADO_PERSONA")
                        .HasColumnType("int");

                    b.Property<int?>("ID_JEFATURA")
                        .HasColumnType("int");

                    b.Property<string>("NOMBRES")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("PASSWORD")
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("RUT")
                        .HasColumnType("int");

                    b.Property<string>("USUARIO_WINDOWS")
                        .HasColumnType("varchar(15)");

                    b.HasKey("ID_PER");

                    b.HasIndex("ID_CENTRO_COSTO");

                    b.HasIndex("ID_ESTADO_PERSONA");

                    b.HasIndex("ID_JEFATURA");

                    b.HasIndex("ID_PER");

                    b.ToTable("PERSONAS");
                });

            modelBuilder.Entity("MinInt.ModuloWeb.Personas.Domain.PersonasSistemas", b =>
                {
                    b.Property<int>("ID_PERMISOS_SISTEMA")
                        .HasColumnType("int");

                    b.Property<int>("ID_PER")
                        .HasColumnType("int");

                    b.Property<int>("ID_SISTEMA")
                        .HasColumnType("int");

                    b.HasKey("ID_PERMISOS_SISTEMA", "ID_PER", "ID_SISTEMA");

                    b.HasIndex("ID_PER");

                    b.HasIndex("ID_SISTEMA");

                    b.ToTable("PERSONAS_SISTEMAS");
                });

            modelBuilder.Entity("MinInt.ModuloWeb.Personas.Domain.PersonasUsuario", b =>
                {
                    b.Property<int>("ID_PER")
                        .HasColumnType("int");

                    b.Property<int>("ID_PERMISOS_USUARIOS")
                        .HasColumnType("int");

                    b.HasKey("ID_PER", "ID_PERMISOS_USUARIOS");

                    b.HasIndex("ID_PERMISOS_USUARIOS");

                    b.ToTable("PERSONAS_USUARIOS");
                });

            modelBuilder.Entity("MinInt.ModuloWeb.Personas.Domain.RegistroEntradaSalida", b =>
                {
                    b.Property<int>("COD_ENTSAL")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("COD_ORIENTACION")
                        .HasColumnType("int");

                    b.Property<DateTime>("FECHA")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("HORA")
                        .HasColumnType("datetime");

                    b.Property<int>("ID_PER")
                        .HasColumnType("int");

                    b.HasKey("COD_ENTSAL");

                    b.HasIndex("COD_ENTSAL");

                    b.HasIndex("COD_ORIENTACION");

                    b.HasIndex("ID_PER");

                    b.ToTable("REGISTRO_ENTRADA_SALIDA");
                });

            modelBuilder.Entity("MinInt.ModuloWeb.Personas.Domain.Sistemas", b =>
                {
                    b.Property<int>("ID_SISTEMA")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DESCRIPCION")
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("PersonasID_PER")
                        .HasColumnType("int");

                    b.HasKey("ID_SISTEMA");

                    b.HasIndex("PersonasID_PER");

                    b.ToTable("SISTEMAS");
                });

            modelBuilder.Entity("MinInt.ModuloWeb.Personas.Domain.Cambios", b =>
                {
                    b.HasOne("MinInt.ModuloWeb.Personas.Domain.EstadoCambios", "ESTADOCAMBIO")
                        .WithMany("CAMBIOS")
                        .HasForeignKey("ID_ESTADO_CAMBIO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MinInt.ModuloWeb.Personas.Domain.Personas", "PERSONA")
                        .WithMany("CAMBIOS")
                        .HasForeignKey("ID_PER")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MinInt.ModuloWeb.Personas.Domain.Jefaturas", b =>
                {
                    b.HasOne("MinInt.ModuloWeb.Personas.Domain.Personas", "JEFE")
                        .WithOne()
                        .HasForeignKey("MinInt.ModuloWeb.Personas.Domain.Jefaturas", "ID_JEFE");

                    b.HasOne("MinInt.ModuloWeb.Personas.Domain.Personas", "SUBROGANTE")
                        .WithOne()
                        .HasForeignKey("MinInt.ModuloWeb.Personas.Domain.Jefaturas", "ID_SUBROGANTE");
                });

            modelBuilder.Entity("MinInt.ModuloWeb.Personas.Domain.Personas", b =>
                {
                    b.HasOne("MinInt.ModuloWeb.Personas.Domain.CentroCosto", "CENTRO_COSTO")
                        .WithMany("PERSONAS")
                        .HasForeignKey("ID_CENTRO_COSTO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MinInt.ModuloWeb.Personas.Domain.EstadoPersona", "ESTADOPERSONA")
                        .WithMany("PERSONAS")
                        .HasForeignKey("ID_ESTADO_PERSONA")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MinInt.ModuloWeb.Personas.Domain.Jefaturas", "JEFATURA")
                        .WithMany("PERSONAS")
                        .HasForeignKey("ID_JEFATURA");
                });

            modelBuilder.Entity("MinInt.ModuloWeb.Personas.Domain.PersonasSistemas", b =>
                {
                    b.HasOne("MinInt.ModuloWeb.Personas.Domain.Personas", "PERSONA")
                        .WithMany()
                        .HasForeignKey("ID_PER")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MinInt.ModuloWeb.Personas.Domain.PersonaSistema", "PERMISOSSISTEMA")
                        .WithMany()
                        .HasForeignKey("ID_PERMISOS_SISTEMA")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MinInt.ModuloWeb.Personas.Domain.Sistemas", "SISTEMAS")
                        .WithMany()
                        .HasForeignKey("ID_SISTEMA")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MinInt.ModuloWeb.Personas.Domain.PersonasUsuario", b =>
                {
                    b.HasOne("MinInt.ModuloWeb.Personas.Domain.Personas", "PERSONA")
                        .WithMany()
                        .HasForeignKey("ID_PER")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MinInt.ModuloWeb.Personas.Domain.PermisosUsuario", "PERMISOSUSUARIO")
                        .WithMany()
                        .HasForeignKey("ID_PERMISOS_USUARIOS")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MinInt.ModuloWeb.Personas.Domain.RegistroEntradaSalida", b =>
                {
                    b.HasOne("MinInt.ModuloWeb.Personas.Domain.Orientacion", "ORIENTACION")
                        .WithMany("REGISTROS")
                        .HasForeignKey("COD_ORIENTACION")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MinInt.ModuloWeb.Personas.Domain.Personas", "PERSONA")
                        .WithMany("REGISTROS")
                        .HasForeignKey("ID_PER")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MinInt.ModuloWeb.Personas.Domain.Sistemas", b =>
                {
                    b.HasOne("MinInt.ModuloWeb.Personas.Domain.Personas", null)
                        .WithMany("SISTEMAS")
                        .HasForeignKey("PersonasID_PER");
                });
#pragma warning restore 612, 618
        }
    }
}
