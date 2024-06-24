namespace user.Models
{
    public class UserDto
    {
        public string Name { get; set; }

        public string Phont { get; set; }
        public DateTime birthday { set; get; }

        public bool Gender { get; set; }
        public string Avatar { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
