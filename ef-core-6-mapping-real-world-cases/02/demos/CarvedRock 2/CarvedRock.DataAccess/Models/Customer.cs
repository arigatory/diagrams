using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarvedRock.DataAccess.Models
{
    public class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        
        [Required, MaxLength(50)]
        public string UserName { get; set; }

        public string FullName => FirstName + " " + LastName;

        [NotMapped]
        public byte[] Checksum { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
