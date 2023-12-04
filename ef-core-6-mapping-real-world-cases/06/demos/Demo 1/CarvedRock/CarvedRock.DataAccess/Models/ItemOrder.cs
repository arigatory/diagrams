namespace CarvedRock.DataAccess.Models
{
    public class ItemOrder
    {
        public Item Item { get; set; }

        public int ItemsId { get; set; }

        public Order Order { get; set; }

        public int OrdersId { get; set; }

        public DateTime OrderDate { get; set; }

        public int Quantity { get; set; }
    }
}