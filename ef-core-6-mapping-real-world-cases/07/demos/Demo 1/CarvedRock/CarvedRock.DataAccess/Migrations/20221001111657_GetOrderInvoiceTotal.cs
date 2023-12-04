using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarvedRock.DataAccess.Migrations
{
    public partial class GetOrderInvoiceTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"CREATE FUNCTION GetTotalInvoiceAmountByOrderId(@orderId int)
                        RETURNS int
                        AS
                        BEGIN
	                        RETURN 
                            (
                                SELECT 
		                            SUM(Items.UnitPrice) 
		                        FROM Orders 
		                        JOIN ItemOrder ON Orders.Id = ItemOrder.OrdersId
		                        JOIN Items ON ItemOrder.ItemsId = Items.Id
		                        WHERE Orders.Id = @orderId
                            );
                        END";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = @"DROP FUNCTION GetTotalInvoiceAmountByOrderId";

            migrationBuilder.Sql(sql);
        }
    }
}
