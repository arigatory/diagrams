using System.ComponentModel.DataAnnotations;

namespace CarvedRock.DataAccess.Models
{
    public class Order
    {
        public Order()
        {
            ItemOrders = new HashSet<ItemOrder>();
        }

        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public Status OrderStatus { get; set; }

        public ICollection<ItemOrder> ItemOrders { get; set; }
    }
}
