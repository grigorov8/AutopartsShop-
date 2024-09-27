using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoPartsShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PartsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "CategoryId", "Description", "ImageFileName", "Manufacturer", "Name", "PartNumber", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "High-performance oil filter for vehicles.", "Oil-Filter.jpg", "MANN", "Oil Filter", "W 719/30", 10.99m, 10 },
                    { 2, 1, "Long-life oil filter suitable for modern engines.", "Oil-Filter.jpg", "MANN", "Oil Filter", "HU 719/6 X", 12.49m, 5 },
                    { 3, 1, "Reliable oil filter for optimal engine protection.", "Oil-Filter.jpg", "MANN", "Oil Filter", "W 712", 8.99m, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
