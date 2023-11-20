using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreGWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ProductsToSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Developer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Developer", "ListPrice", "Price100", "Price50", "ProductName", "Publisher" },
                values: new object[,]
                {
                    { 1, "Elden Ring Description", "FromSoftware, Inc", 31.0, 21.0, 26.0, "Elden Ring", "BANDAI NAMCO Entertainment, FromSoftware, Inc " },
                    { 2, "F1 23 Description", "Codemasters", 41.0, 31.0, 36.0, "F1 23", "Electronic Arts" },
                    { 3, "Final Fantasy VII - Intergrade Description", "Square Enix", 39.0, 29.0, 34.0, "Final Fantasy VII - Intergrade", "Square Enix" },
                    { 4, "Resident Evil 4 - Remake Description", "CAPCOM Co., Ltd.", 30.0, 20.0, 25.0, "Resident Evil 4 - Remake", "CAPCOM Co., Ltd." },
                    { 5, "Lies of P Description", "NEOWIZ", 36.0, 26.0, 31.0, "Lies of P", "NEOWIZ" },
                    { 6, "Risk of Rain Returns Description", "Hopoo Games", 30.0, 20.0, 25.0, "Risk of Rain Returns", "Gearbox Publishing" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
