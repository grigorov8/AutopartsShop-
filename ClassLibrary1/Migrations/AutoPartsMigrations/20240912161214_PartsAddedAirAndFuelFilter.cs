﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoPartsShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PartsAddedAirAndFuelFilter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "CategoryId", "Description", "ImageFileName", "Manufacturer", "Name", "PartNumber", "Price", "Stock" },
                values: new object[,]
                {
                    { 4, 2, "High-efficiency air filter for improved engine performance.", "Air-Filter.jpg", "MANN", "Air Filter", "C 25 024", 15.99m, 10 },
                    { 5, 2, "Durable air filter for superior filtration and protection.", "Air-Filter.jpg", "MANN", "Air Filter", "C 18 001", 13.49m, 10 },
                    { 6, 2, "Advanced air filter for enhanced air flow and engine efficiency.", "Air-Filter.jpg", "MANN", "Air Filter", "C 37 153", 18.99m, 20 },
                    { 7, 3, "High-performance fuel filter for efficient fuel filtration.", "Fuel-Filter.jpg", "MANN", "Fuel Filter", "F 00 000 000", 25.99m, 20 },
                    { 8, 3, "Durable fuel filter for reliable performance and protection.", "Fuel-Filter.jpg", "MANN", "Fuel Filter", "F 00 000 001", 28.49m, 15 },
                    { 9, 3, "Advanced fuel filter for optimal engine efficiency.", "Fuel-Filter.jpg", "MANN", "Fuel Filter", "F 00 000 002", 30.99m, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}