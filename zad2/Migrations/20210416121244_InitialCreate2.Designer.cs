﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using zad2;

namespace zad2.Migrations
{
    [DbContext(typeof(WeatherByCity))]
    [Migration("20210416121244_InitialCreate2")]
    partial class InitialCreate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("zad2.WeatherForDB", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("TEXT");

                    b.Property<string>("clouds")
                        .HasColumnType("TEXT");

                    b.Property<float>("feels_like")
                        .HasColumnType("REAL");

                    b.Property<float>("humidity")
                        .HasColumnType("REAL");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<float>("pressure")
                        .HasColumnType("REAL");

                    b.Property<float>("temp")
                        .HasColumnType("REAL");

                    b.Property<float>("temp_max")
                        .HasColumnType("REAL");

                    b.Property<float>("temp_min")
                        .HasColumnType("REAL");

                    b.Property<float>("windDeg")
                        .HasColumnType("REAL");

                    b.Property<float>("windSpeed")
                        .HasColumnType("REAL");

                    b.HasKey("id");

                    b.ToTable("WeatherForDB");
                });
#pragma warning restore 612, 618
        }
    }
}
