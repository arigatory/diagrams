using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarvedRock.DataAccess.Migrations
{
    public partial class GetCustomerOrdersByCustomerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"CREATE FUNCTION GetCustomerOrdersByCustomerId(@customerId int)
                        RETURNS TABLE 
                        AS
                        RETURN 
                        (
	                        SELECT 
		                        Orders.Id AS OrderId, 
		                        Orders.Name AS OrderName, 
		                        Customers.Id AS CustomerId, 
		                        CONCAT(Customers.FirstName,' ', Customers.LastName) AS CustomerName,
		                        Items.Description AS ItemDescription,
		                        Items.UnitPrice,
		                        Items.UnitPriceAfterVAT 
	                        FROM ItemOrder
	                        JOIN Items ON ItemOrder.ItemsId = Items.Id
	                        JOIN Orders ON ItemOrder.OrdersId = Orders.Id
	                        JOIN Customers ON Orders.CustomerId = Customers.Id
	                        WHERE Customers.Id = @customerId
                        );";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = @"DROP FUNCTION GetCustomerOrdersByCustomerId";

            migrationBuilder.Sql(sql);
        }
    }
}
