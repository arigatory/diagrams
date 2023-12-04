using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, MaxLength(50)]
        //public string UserName { get; set; }        
        public string Username
        {
            get
            {
                return _validUsername;
            }
        }

        public string FullName => FirstName + " " + LastName;

        [NotMapped]
        public byte[] Checksum { get; set; }

        public ICollection<Order> Orders { get; set; }

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
