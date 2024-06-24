using AutoMapper;
using Microsoft.AspNetCore.Identity;
using user.Repositories.RepoUser;

namespace user.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestDbContext _context;
        public UnitOfWork(TestDbContext context, IMapper mapper)
        {
            _context = context;
            Users = new UserRepository(context, mapper);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public IUserRepository Users { get; private set; }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
