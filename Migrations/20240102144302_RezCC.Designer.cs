﻿// <auto-generated />
using System;
using HotelBookingWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelBookingWeb.Migrations
{
    [DbContext(typeof(HotelBookingWebContext))]
    [Migration("20240102144302_RezCC")]
    partial class RezCC
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HotelBookingWeb.Models.Camera", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descriere")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("Disponibilitate")
                        .HasColumnType("bit");

                    b.Property<string>("Numar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Camera");
                });

            modelBuilder.Entity("HotelBookingWeb.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("HotelBookingWeb.Models.Rezervare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CameraId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataSfarsit")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoteAditionale")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("CameraId");

                    b.HasIndex("ClientId");

                    b.ToTable("Rezervare");
                });

            modelBuilder.Entity("HotelBookingWeb.Models.Rezervare", b =>
                {
                    b.HasOne("HotelBookingWeb.Models.Camera", "Camera")
                        .WithMany("Rezervari")
                        .HasForeignKey("CameraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelBookingWeb.Models.Client", "Client")
                        .WithMany("Rezervari")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camera");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("HotelBookingWeb.Models.Camera", b =>
                {
                    b.Navigation("Rezervari");
                });

            modelBuilder.Entity("HotelBookingWeb.Models.Client", b =>
                {
                    b.Navigation("Rezervari");
                });
#pragma warning restore 612, 618
        }
    }
}
