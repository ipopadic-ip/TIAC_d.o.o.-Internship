using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektniZadatakTiac.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Password { get; set; }
        public bool IsActive { get; set; }

        // Dodajte navigaciono svojstvo koje označava korisnike koje ovaj korisnik prati
        public ICollection<User> Followers { get; set; } = new List<User>();

        // Dodajte navigaciono svojstvo koje označava korisnike koje ovaj korisnik prati
        public ICollection<User> Following { get; set; } = new List<User>();
    }
}
