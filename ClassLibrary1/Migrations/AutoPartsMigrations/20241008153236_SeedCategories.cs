using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPartsShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

                 migrationBuilder.InsertData(
             table: "Categories",
              columns: new[] { "Id", "Name" },
              values: new object[,]
              {
                 { 1, "Filters" },
                 { 2, "Engine" },
                 { 3, "Brake" }
        });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
