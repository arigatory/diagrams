using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarvedRock.DataAccess.Migrations
{
    public partial class OwnedEntityTypesUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "ShipToAddress_Street",
                table: "Customers",
                newName: "ShipToStreet");

            migrationBuilder.CreateTable(
                name: "BillToAddresses",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillToAddresses", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_BillToAddresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillToAddresses");

            migrationBuilder.RenameColumn(
                name: "ShipToStreet",
                table: "Customers",
                newName: "ShipToAddress_Street");

            migrationBuilder.AddColumn<string>(
                name: "BillToAddress_City",
                table: "Customers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillToAddress_Country",
                table: "Customers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillToAddress_Street",
                table: "Customers",
                type: "nvarchar(100)",
                nullable: true);
        }
    }
}
