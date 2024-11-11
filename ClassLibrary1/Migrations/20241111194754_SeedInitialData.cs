using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoPartsShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "EngineCapacity", "Image", "Make", "Model", "Vin", "Year" },
                values: new object[,]
                {
                    { 1, 2.0m, "", "Audi", "A4", "WAUZZZ8K4AA123456", 2020 },
                    { 2, 2.0m, "", "BMW", "3 Series", "WBAVB33506KV12345", 2019 },
                    { 3, 1.8m, "", "Mercedes", "C-Class", "WDDGF81X98F123456", 2021 },
                    { 4, 1.6m, "", "Volkswagen", "Golf", "WVWZZZ1KZBW123456", 2018 },
                    { 5, 1.4m, "", "Skoda", "Octavia", "TMBJK73T0A0123456", 2022 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Engine" },
                    { 2, "Brakes" },
                    { 3, "Suspension" },
                    { 4, "Filters" },
                    { 5, "Oils" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "AverageRating", "CategoryId", "Description", "ImageFileName", "Manufacturer", "Name", "PartNumber", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 4.5, 4, "", "", "MANN", "Air Filter", "AF123", 20.5m, 5 },
                    { 2, 4.2000000000000002, 4, "", "", "MANN", "Fuel Filter", "FF123", 15.0m, 4 },
                    { 3, 4.0, 4, "", "", "MANN", "Oil Filter", "OF123", 10.0m, 3 },
                    { 4, 4.5999999999999996, 3, "", "", "SuspensionPro", "Control Arm", "CA123", 120.0m, 20 },
                    { 5, 4.2999999999999998, 2, "", "", "BrakeKing", "Brake Pads", "BP123", 60.0m, 45 },
                    { 6, 4.4000000000000004, 2, "", "", "BrakeKing", "Brake Discs", "BD123", 85.0m, 30 },
                    { 7, 4.5, 1, "", "", "EngineTech", "Piston", "PI123", 220.0m, 15 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Manufacturer", "Name", "Price", "ProductNumber", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 5, "High quality engine oil for better performance.", "", "Castrol", "Engine Oil 5W-30", 45.0m, "EO530", 10 },
                    { 2, 5, "Special transmission oil for smoother shifting.", "", "Castrol", "Transmission Oil", 55.0m, "TO123", 8 },
                    { 3, 5, "Hydraulic oil for industrial machinery.", "", "Castrol", "Hydraulic Oil", 30.0m, "HO123", 7 }
                });

            migrationBuilder.InsertData(
                table: "CarParts",
                columns: new[] { "Id", "CarId", "PartId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 1, 5 },
                    { 6, 2, 6 },
                    { 7, 3, 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarParts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarParts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarParts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarParts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarParts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CarParts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CarParts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 3);

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
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
