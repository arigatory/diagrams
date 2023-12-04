using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarvedRock.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TableperType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanningMaterial",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Fabric",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ProductionDate",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PublicationFrequency",
                table: "Items");

            migrationBuilder.CreateTable(
                name: "CannedFoodItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CanningMaterial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CannedFoodItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CannedFoodItems_Items_Id",
                        column: x => x.Id,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClothesItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Fabric = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothesItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClothesItems_Items_Id",
                        column: x => x.Id,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriedFoodItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriedFoodItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriedFoodItems_Items_Id",
                        column: x => x.Id,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MagazineItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PublicationFrequency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagazineItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagazineItems_Items_Id",
                        column: x => x.Id,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CannedFoodItems");

            migrationBuilder.DropTable(
                name: "ClothesItems");

            migrationBuilder.DropTable(
                name: "DriedFoodItems");

            migrationBuilder.DropTable(
                name: "MagazineItems");

            migrationBuilder.AddColumn<string>(
                name: "CanningMaterial",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "Items",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fabric",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemType",
                table: "Items",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "UncategorizedItem");

            migrationBuilder.AddColumn<DateTime>(
                name: "ProductionDate",
                table: "Items",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicationFrequency",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
