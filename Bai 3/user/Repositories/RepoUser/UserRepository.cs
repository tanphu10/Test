using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using user.Entities;

namespace user.Repositories.RepoUser
{
    public class UserRepository : RepositoryBase<User, Guid>, IUserRepository
    {
        private readonly TestDbContext _context;
        private readonly IMapper _mapper;
        public UserRepository(TestDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> FindEmail(string Email)
        {
            return await _context.Users.Where(x => x.Email == Email).FirstOrDefaultAsync();
        }
    }
}
