namespace CarvedRock.DataAccess.Models
{
    public class Order
    {
        public Order()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        
        public string Name { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
