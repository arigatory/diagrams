using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarvedRock.DataAccess.Migrations
{
    public partial class GetOrdersByCustomerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"CREATE PROCEDURE GetOrdersByCustomerId
	                        @customerId int,
							@customerOrderCount int OUTPUT
                        AS
                        BEGIN
	                        SELECT * FROM Orders WHERE CustomerId = @customerId
							SET @customerOrderCount = (SELECT COUNT(*) FROM Orders WHERE CustomerId = @customerId)
                        END";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = @"DROP PROCEDURE GetOrdersByCustomerId";

            migrationBuilder.Sql(sql);
        }
    }
}
