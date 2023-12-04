using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarvedRock.DataAccess.Migrations
{
    public partial class Fluent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Items",
                type: "decimal(22,2)",
                nullable: false,
                defaultValue: 100m,
                oldClrType: typeof(decimal),
                oldType: "decimal(22,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPriceAfterVAT",
                table: "Items",
                type: "decimal(22,2)",
                nullable: false,
                computedColumnSql: "[UnitPrice]*1.10");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Customers_Username",
                table: "Customers",
                column: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Customers_Username",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UnitPriceAfterVAT",
                table: "Items");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Items",
                type: "decimal(22,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(22,2)",
                oldDefaultValue: 100m);
        }
    }
}
