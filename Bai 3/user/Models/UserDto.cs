using AutoMapper;
using user.Entities;

namespace user.Models
{
    public class UserDto
    {
        public string Name { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime birthday { set; get; }

        public bool Gender { get; set; }
        public string Avatar { get; set; }
        public DateTime CreatedAt { get; set; }
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<User, UserDto>().ReverseMap();
            }
        }
    }
}
