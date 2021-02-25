﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkyAPI.Data;

namespace ParkyAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210121123722_AddBreadAndTypeScript")]
    partial class AddBreadAndTypeScript
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ParkyAPI.Models.Bread", b =>
                {
                    b.Property<int>("BreadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("TypeBreadId")
                        .HasColumnType("int");

                    b.HasKey("BreadId");

                    b.HasIndex("TypeBreadId");

                    b.ToTable("Breads");
                });

            modelBuilder.Entity("ParkyAPI.Models.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BreadId")
                        .HasColumnType("int");

                    b.Property<string>("ImageFile")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImageId");

                    b.HasIndex("BreadId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("ParkyAPI.Models.NationalPark", b =>
                {
                    b.Property<int>("NationalParkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Established")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("NationalParkId");

                    b.ToTable("NationalParks");
                });

            modelBuilder.Entity("ParkyAPI.Models.TypeBread", b =>
                {
                    b.Property<int>("TypeBreadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("TypeBreadId");

                    b.ToTable("TypeBreads");
                });

            modelBuilder.Entity("ParkyAPI.Models.Bread", b =>
                {
                    b.HasOne("ParkyAPI.Models.TypeBread", "TypeBread")
                        .WithMany("Breads")
                        .HasForeignKey("TypeBreadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeBread");
                });

            modelBuilder.Entity("ParkyAPI.Models.Image", b =>
                {
                    b.HasOne("ParkyAPI.Models.Bread", "Bread")
                        .WithMany("Images")
                        .HasForeignKey("BreadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bread");
                });

            modelBuilder.Entity("ParkyAPI.Models.Bread", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("ParkyAPI.Models.TypeBread", b =>
                {
                    b.Navigation("Breads");
                });
#pragma warning restore 612, 618
        }
    }
}