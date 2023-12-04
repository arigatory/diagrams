namespace CarvedRock.DataAccess.Models
{
    public class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
                
        public string UserName { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
