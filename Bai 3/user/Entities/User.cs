using System.ComponentModel.DataAnnotations.Schema;

namespace user.Entities
{
    [Table("User")]
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
       
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime birthday { set; get; }

        public bool Gender { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
