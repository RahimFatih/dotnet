// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace pogodynka.Migrations
{
    [DbContext(typeof(RazorPagesGameContext))]
    [Migration("20210423142426_InitialCreate")]
    partial class InitialCreate
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
#pragma warning restore 612, 618
        }
    }
}
