﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekt.AppService;

#nullable disable

namespace Projekt.AppService.Migrations
{
    [DbContext(typeof(ProjektDb))]
    [Migration("20220621184428_FloatsMigration")]
    partial class FloatsMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Projekt.AppService.Models.ControlTemp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("ControlTemperature")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("ControlTemps", (string)null);
                });

            modelBuilder.Entity("Projekt.AppService.Models.Measurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DateMeasured")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<float>("Humidity")
                        .HasColumnType("real");

                    b.Property<float>("TemperatureC")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Measurements", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
