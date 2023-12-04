using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarvedRock.DataAccess.Migrations
{
    public partial class Unitprice : Migration
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

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPriceAfterVAT",
                table: "Items",
                type: "decimal(22,2)",
                nullable: false,
                computedColumnSql: "[UnitPrice]*1.10",
                oldClrType: typeof(decimal),
                oldType: "decimal(22,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPriceAfterVAT",
                table: "Items",
                type: "decimal(22,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(22,2)",
                oldComputedColumnSql: "[UnitPrice]*1.10");

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
