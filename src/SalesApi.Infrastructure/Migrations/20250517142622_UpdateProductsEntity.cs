using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "products",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "products",
                newName: "Name");
        }
    }
}
