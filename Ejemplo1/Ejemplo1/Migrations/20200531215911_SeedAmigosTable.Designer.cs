﻿// <auto-generated />
using Ejemplo1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ejemplo1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200531215911_SeedAmigosTable")]
    partial class SeedAmigosTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ejemplo1.Models.Amigo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ciudad");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("AppDbContextAmigos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ciudad = 1,
                            Email = "yiyo@sk.com",
                            Nombre = "Juan"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
