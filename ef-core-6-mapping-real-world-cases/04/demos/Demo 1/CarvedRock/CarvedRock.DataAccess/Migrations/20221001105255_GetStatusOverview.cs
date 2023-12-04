using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarvedRock.DataAccess.Migrations
{
    public partial class GetStatusOverview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"CREATE FUNCTION GetStatusOverview()
						RETURNS 
						@statuses TABLE 
						(
							Id int,
							Status NVARCHAR(MAX),
							Source NVARCHAR(MAX)
						)
						AS
						BEGIN
							INSERT INTO @statuses
							SELECT 
								Id,
								CustomerStatus AS Status,
								'Customers' AS Source
							FROM Customers 
		
							INSERT INTO @statuses
							SELECT 
								Id,
								OrderStatus AS Status,
								'Orders' AS Source
							FROM Orders 
							RETURN 
						END";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = @"DROP FUNCTION GetStatusOverview";

            migrationBuilder.Sql(sql);
        }
    }
}
