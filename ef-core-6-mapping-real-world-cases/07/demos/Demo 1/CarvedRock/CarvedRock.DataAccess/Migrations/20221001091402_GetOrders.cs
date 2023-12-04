using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarvedRock.DataAccess.Migrations
{
    public partial class GetOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"CREATE PROCEDURE GetOrders
                        AS
                        BEGIN
	                        SELECT * FROM Orders
                        END
                        GO";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = @"DROP PROCEDURE GetOrders";
       
            migrationBuilder.Sql(sql);
        }
    }
}
