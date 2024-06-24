namespace user.Models
{
    public class CreateUser
    {
        public string Name { get; set; }

        public string Phone { get; set; }
        public DateTime birthday { set; get; }

        public bool Gender { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
