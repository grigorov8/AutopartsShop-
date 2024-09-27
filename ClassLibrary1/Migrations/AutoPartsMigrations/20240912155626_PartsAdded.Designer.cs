﻿// <auto-generated />
using AutoPartsShop.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoPartsShop.Infrastructure.Migrations
{
    [DbContext(typeof(AutoPartsShopDbContext))]
    [Migration("20240912155626_PartsAdded")]
    partial class PartsAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutoPartsShop.Infrastructure.Database.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EngineId")
                        .HasColumnType("int");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Vin")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EngineId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("AutoPartsShop.Infrastructure.Database.Models.CarPart", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("PartId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("CarId", "PartId");

                    b.HasIndex("PartId");

                    b.ToTable("CarParts");
                });

            modelBuilder.Entity("AutoPartsShop.Infrastructure.Database.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Oil Filters"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Air Filters"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Fuel Filters"
                        });
                });

            modelBuilder.Entity("AutoPartsShop.Infrastructure.Database.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("AutoPartsShop.Infrastructure.Database.Models.Engine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Displacement")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("HorsePower")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Engines");
                });

            modelBuilder.Entity("AutoPartsShop.Infrastructure.Database.Models.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ImageFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PartNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Parts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "High-performance oil filter for vehicles.",
                            ImageFileName = "Oil-Filter.jpg",
                            Manufacturer = "MANN",
                            Name = "Oil Filter",
                            PartNumber = "W 719/30",
                            Price = 10.99m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Long-life oil filter suitable for modern engines.",
                            ImageFileName = "Oil-Filter.jpg",
                            Manufacturer = "MANN",
                            Name = "Oil Filter",
                            PartNumber = "HU 719/6 X",
                            Price = 12.49m,
                            Stock = 5
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Reliable oil filter for optimal engine protection.",
                            ImageFileName = "Oil-Filter.jpg",
                            Manufacturer = "MANN",
                            Name = "Oil Filter",
                            PartNumber = "W 712",
                            Price = 8.99m,
                            Stock = 3
                        });
                });

            modelBuilder.Entity("AutoPartsShop.Infrastructure.Database.Models.Car", b =>
                {
                    b.HasOne("AutoPartsShop.Infrastructure.Database.Models.Engine", "Engine")
                        .WithMany("Cars")
                        .HasForeignKey("EngineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Engine");
                });

            modelBuilder.Entity("AutoPartsShop.Infrastructure.Database.Models.CarPart", b =>
                {
                    b.HasOne("AutoPartsShop.Infrastructure.Database.Models.Car", "Car")
                        .WithMany("CarParts")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoPartsShop.Infrastructure.Database.Models.Part", "Part")
                        .WithMany("CarParts")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Part");
                });

            modelBuilder.Entity("AutoPartsShop.Infrastructure.Database.Models.Part", b =>
                {
                    b.HasOne("AutoPartsShop.Infrastructure.Database.Models.Category", "Category")
                        .WithMany("Parts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("AutoPartsShop.Infrastructure.Database.Models.Car", b =>
                {
                    b.Navigation("CarParts");
                });

            modelBuilder.Entity("AutoPartsShop.Infrastructure.Database.Models.Category", b =>
                {
                    b.Navigation("Parts");
                });

            modelBuilder.Entity("AutoPartsShop.Infrastructure.Database.Models.Engine", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("AutoPartsShop.Infrastructure.Database.Models.Part", b =>
                {
                    b.Navigation("CarParts");
                });
#pragma warning restore 612, 618
        }
    }
}