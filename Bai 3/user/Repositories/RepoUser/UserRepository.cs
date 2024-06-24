using Microsoft.AspNetCore.Identity;
using user.Entities;

namespace user.Repositories.RepoUser
{
    public class UserRepository : RepositoryBase<User, Guid>, IUserRepository
    {
        private readonly TestDbContext _context;
        public UserRepository(TestDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
