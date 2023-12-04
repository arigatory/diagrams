using System.ComponentModel.DataAnnotations;

namespace CarvedRock.DataAccess.Models
{
    public class Customer
    {
        private string _validUsername;

        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        //[NotMapped]
        //public byte[] Checksum { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, MaxLength(50)]             
        public string Username
        {
            get
            {
                return _validUsername;
            }
        }

        public string FullName => FirstName + " " + LastName;

        public ICollection<Order> Orders { get; set; }

        private readonly Dictionary<string, object> _data = new Dictionary<string, object>();

        public object this[string key]
        {
            get => _data[key];
            set => _data[key] = value;
        }

        public Address ShipToAddress { get; set; }

        public Address BillToAddress { get; set; }


        public Status CustomerStatus { get; set; }








        









        public void SetUsername(string username)
        {
            string specialCharacters = ".*(?=.*[@#$%^&+=(){}<>!~_*?]).*$";

            bool usernameContainsSpecialCharacters = username.Any(c => specialCharacters.Contains(c));
            if (usernameContainsSpecialCharacters)
            {
                throw new ArgumentException("Special characters are not allowed in username", username);
            }

            _validUsername = username;
        }















    }
}
