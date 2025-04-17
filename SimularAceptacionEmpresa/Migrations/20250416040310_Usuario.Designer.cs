﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimularAceptacionEmpresa.DAL;

#nullable disable

namespace SimularAceptacionEmpresa.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20250416040310_Usuario")]
    partial class Usuario
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.4");

            modelBuilder.Entity("SimularAceptacionEmpresa.Models.Actividades", b =>
                {
                    b.Property<string>("ActividadId")
                        .HasColumnType("TEXT");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("valoracion")
                        .HasColumnType("INTEGER");

                    b.HasKey("ActividadId");

                    b.ToTable("Actividades");
                });

            modelBuilder.Entity("SimularAceptacionEmpresa.Models.Empresas", b =>
                {
                    b.Property<int>("EmpresaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EmpresaId");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("SimularAceptacionEmpresa.Models.Ingresos", b =>
                {
                    b.Property<int>("IngresoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IngresoId");

                    b.ToTable("Ingresos");
                });

            modelBuilder.Entity("SimularAceptacionEmpresa.Models.Preguntas", b =>
                {
                    b.Property<int>("PreguntaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PreguntaId");

                    b.ToTable("Preguntas");
                });

            modelBuilder.Entity("SimularAceptacionEmpresa.Models.PreguntasDetalle", b =>
                {
                    b.Property<int>("PreguntaDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PreguntaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Respuesta")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Valoracion")
                        .HasColumnType("INTEGER");

                    b.HasKey("PreguntaDetalleId");

                    b.HasIndex("PreguntaId");

                    b.ToTable("PreguntasDetalle");
                });

            modelBuilder.Entity("SimularAceptacionEmpresa.Models.Recursos", b =>
                {
                    b.Property<int>("RecursoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RecursoId");

                    b.ToTable("Recursos");
                });

            modelBuilder.Entity("SimularAceptacionEmpresa.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SimularAceptacionEmpresa.Models.UsuariosDetalle", b =>
                {
                    b.Property<int>("UsuarioDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PreguntaDetalleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PreguntaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UsuarioDetalleId");

                    b.HasIndex("PreguntaDetalleId");

                    b.HasIndex("PreguntaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuariosDetalle");
                });

            modelBuilder.Entity("SimularAceptacionEmpresa.Models.PreguntasDetalle", b =>
                {
                    b.HasOne("SimularAceptacionEmpresa.Models.Preguntas", null)
                        .WithMany("PreguntasDetalle")
                        .HasForeignKey("PreguntaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SimularAceptacionEmpresa.Models.UsuariosDetalle", b =>
                {
                    b.HasOne("SimularAceptacionEmpresa.Models.PreguntasDetalle", "PreguntaDetalle")
                        .WithMany()
                        .HasForeignKey("PreguntaDetalleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimularAceptacionEmpresa.Models.Preguntas", "Pregunta")
                        .WithMany()
                        .HasForeignKey("PreguntaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimularAceptacionEmpresa.Models.Usuario", "Usuario")
                        .WithMany("UsuariosDetalle")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pregunta");

                    b.Navigation("PreguntaDetalle");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SimularAceptacionEmpresa.Models.Preguntas", b =>
                {
                    b.Navigation("PreguntasDetalle");
                });

            modelBuilder.Entity("SimularAceptacionEmpresa.Models.Usuario", b =>
                {
                    b.Navigation("UsuariosDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
