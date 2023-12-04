using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarvedRock.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateTableperHierarchy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "ItemSequence");

            migrationBuilder.CreateTable(
                name: "CannedFoodItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ItemSequence]"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(22,2)", nullable: false, defaultValue: 100m),
                    UnitPriceAfterVAT = table.Column<decimal>(type: "decimal(22,2)", nullable: false, computedColumnSql: "[UnitPrice]*1.10"),
                    UnitWeight = table.Column<double>(type: "float(36)", nullable: false),
                    CanningMaterial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CannedFoodItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClothesItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ItemSequence]"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(22,2)", nullable: false, defaultValue: 100m),
                    UnitPriceAfterVAT = table.Column<decimal>(type: "decimal(22,2)", nullable: false, computedColumnSql: "[UnitPrice]*1.10"),
                    UnitWeight = table.Column<double>(type: "float(36)", nullable: false),
                    Fabric = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothesItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShipToAddressStreet = table.Column<string>(name: "ShipToAddress_Street", type: "nvarchar(100)", nullable: true),
                    ShipToAddressCity = table.Column<string>(name: "ShipToAddress_City", type: "nvarchar(100)", nullable: true),
                    ShipToAddressCountry = table.Column<string>(name: "ShipToAddress_Country", type: "nvarchar(100)", nullable: true),
                    BillToAddressStreet = table.Column<string>(name: "BillToAddress_Street", type: "nvarchar(100)", nullable: true),
                    BillToAddressCity = table.Column<string>(name: "BillToAddress_City", type: "nvarchar(100)", nullable: true),
                    BillToAddressCountry = table.Column<string>(name: "BillToAddress_Country", type: "nvarchar(100)", nullable: true),
                    CustomerStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Checksum = table.Column<byte[]>(type: "varbinary(max)", nullable: true, computedColumnSql: "CONVERT(VARBINARY(1024),CHECKSUM([FirstName],[LastName],[UserName]))"),
                    ConsumerType = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.UniqueConstraint("AK_Customers_Username", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "DriedFoodItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ItemSequence]"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(22,2)", nullable: false, defaultValue: 100m),
                    UnitPriceAfterVAT = table.Column<decimal>(type: "decimal(22,2)", nullable: false, computedColumnSql: "[UnitPrice]*1.10"),
                    UnitWeight = table.Column<double>(type: "float(36)", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriedFoodItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ItemSequence]"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(22,2)", nullable: false, defaultValue: 100m),
                    UnitPriceAfterVAT = table.Column<decimal>(type: "decimal(22,2)", nullable: false, computedColumnSql: "[UnitPrice]*1.10"),
                    UnitWeight = table.Column<double>(type: "float(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MagazineItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ItemSequence]"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(22,2)", nullable: false, defaultValue: 100m),
                    UnitPriceAfterVAT = table.Column<decimal>(type: "decimal(22,2)", nullable: false, computedColumnSql: "[UnitPrice]*1.10"),
                    UnitWeight = table.Column<double>(type: "float(36)", nullable: false),
                    PublicationFrequency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagazineItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DiscountRate = table.Column<int>(type: "int", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemOrder",
                columns: table => new
                {
                    ItemsId = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOrder", x => new { x.ItemsId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_ItemOrder_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_FirstName_LastName",
                table: "Customers",
                columns: new[] { "FirstName", "LastName" });

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrder_OrdersId",
                table: "ItemOrder",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Name",
                table: "Orders",
                column: "Name");
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
                name: "ItemOrder");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "MagazineItems");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropSequence(
                name: "ItemSequence");
        }
    }
}
