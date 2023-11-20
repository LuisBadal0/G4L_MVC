﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreGWeb.DataAccess.Data;

#nullable disable

namespace StoreGWeb.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231120194045_ProductsToSeed")]
    partial class ProductsToSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StoreG.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "RPG"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Sports"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 3,
                            Name = "Horror"
                        });
                });

            modelBuilder.Entity("StoreG.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Developer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<double>("Price100")
                        .HasColumnType("float");

                    b.Property<double>("Price50")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Elden Ring Description",
                            Developer = "FromSoftware, Inc",
                            ListPrice = 31.0,
                            Price100 = 21.0,
                            Price50 = 26.0,
                            ProductName = "Elden Ring",
                            Publisher = "BANDAI NAMCO Entertainment, FromSoftware, Inc "
                        },
                        new
                        {
                            Id = 2,
                            Description = "F1 23 Description",
                            Developer = "Codemasters",
                            ListPrice = 41.0,
                            Price100 = 31.0,
                            Price50 = 36.0,
                            ProductName = "F1 23",
                            Publisher = "Electronic Arts"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Final Fantasy VII - Intergrade Description",
                            Developer = "Square Enix",
                            ListPrice = 39.0,
                            Price100 = 29.0,
                            Price50 = 34.0,
                            ProductName = "Final Fantasy VII - Intergrade",
                            Publisher = "Square Enix"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Resident Evil 4 - Remake Description",
                            Developer = "CAPCOM Co., Ltd.",
                            ListPrice = 30.0,
                            Price100 = 20.0,
                            Price50 = 25.0,
                            ProductName = "Resident Evil 4 - Remake",
                            Publisher = "CAPCOM Co., Ltd."
                        },
                        new
                        {
                            Id = 5,
                            Description = "Lies of P Description",
                            Developer = "NEOWIZ",
                            ListPrice = 36.0,
                            Price100 = 26.0,
                            Price50 = 31.0,
                            ProductName = "Lies of P",
                            Publisher = "NEOWIZ"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Risk of Rain Returns Description",
                            Developer = "Hopoo Games",
                            ListPrice = 30.0,
                            Price100 = 20.0,
                            Price50 = 25.0,
                            ProductName = "Risk of Rain Returns",
                            Publisher = "Gearbox Publishing"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
