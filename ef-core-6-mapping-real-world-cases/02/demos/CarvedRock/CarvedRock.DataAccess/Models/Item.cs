namespace CarvedRock.DataAccess.Models
{
    public class Item
    {
        public Item()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        
        public string Description { get; set; }
        
        public decimal Price { get; set; }

        public float Weight { get; set; }   

        public ICollection<Order> Orders { get; set; }

    }
}
