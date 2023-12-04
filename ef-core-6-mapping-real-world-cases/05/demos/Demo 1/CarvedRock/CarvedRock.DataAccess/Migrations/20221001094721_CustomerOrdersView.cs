using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarvedRock.DataAccess.Migrations
{
    public partial class CustomerOrdersView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"CREATE VIEW CustomerOrdersView AS
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
                        JOIN Customers ON Orders.CustomerId = Customers.Id";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = @"DROP VIEW CustomerOrdersView";

            migrationBuilder.Sql(sql);
        }
    }
}
