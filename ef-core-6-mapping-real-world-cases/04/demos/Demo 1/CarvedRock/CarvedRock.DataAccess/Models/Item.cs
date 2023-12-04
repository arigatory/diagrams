using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarvedRock.DataAccess.Models
{
    public class Item
    {
        public Item()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Description { get; set; }

        [Column("UnitPrice", TypeName = "decimal(22,2)")]
        public decimal Price { get; set; }

        [Column("UnitPriceAfterVAT", TypeName = "decimal(22,2)")]
        public decimal PriceAfterVat { get; set; }

        [Column("UnitWeight", TypeName = "float(36)")]
        public float Weight { get; set; }   

        public ICollection<Order> Orders { get; set; }
    }
}
