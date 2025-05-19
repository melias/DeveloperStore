using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSalesItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValueMonetaryTaxApplied",
                table: "sale_items",
                newName: "Discount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "sale_items",
                newName: "ValueMonetaryTaxApplied");
        }
    }
}
