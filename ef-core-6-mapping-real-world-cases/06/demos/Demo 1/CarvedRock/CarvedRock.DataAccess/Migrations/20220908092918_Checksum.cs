using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarvedRock.DataAccess.Migrations
{
    public partial class Checksum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Checksum",
                table: "Customers",
                type: "varbinary(max)",
                nullable: true,
                computedColumnSql: "CONVERT(VARBINARY(1024),CHECKSUM([FirstName],[LastName],[UserName]))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Checksum",
                table: "Customers");
        }
    }
}
