// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace pogodynka.Migrations
{
    [DbContext(typeof(RazorPagesGameContext))]
    [Migration("20210430123329_InitialCreateWeather2")]
    partial class InitialCreateWeather2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cena")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataWydania")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gatunek")
                        .HasColumnType("TEXT");

                    b.Property<string>("Platforma")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tytuł")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("Weather", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("cod")
                        .HasColumnType("INTEGER");

                    b.Property<int>("dt")
                        .HasColumnType("INTEGER");

                    b.Property<float>("mainWeatherTemp")
                        .HasColumnType("REAL");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<int>("timezone")
                        .HasColumnType("INTEGER");

                    b.Property<float>("visibility")
                        .HasColumnType("REAL");

                    b.Property<string>("weatherDescription")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Weather");
                });
#pragma warning restore 612, 618
        }
    }
}
