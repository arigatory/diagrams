using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarvedRock.DataAccess.Migrations
{
    public partial class OwnedEntityTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BillToAddress_City",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillToAddress_Country",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillToAddress_Street",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShipToAddress_City",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShipToAddress_Country",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShipToAddress_Street",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillToAddress_City",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BillToAddress_Country",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BillToAddress_Street",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ShipToAddress_City",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ShipToAddress_Country",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ShipToAddress_Street",
                table: "Customers");
        }
    }
}
