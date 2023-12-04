namespace CarvedRock.DataAccess.Models
{
    public class CustomerOrder
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ItemDescription { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceAfterVAT { get; set; }
    }
}