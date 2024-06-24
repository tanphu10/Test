using user.Entities;

namespace user.Repositories.RepoUser
{
    public interface IUserRepository : IRepository<User, Guid>
    {

        Task<User> FindEmail(string Email);

    }
}
