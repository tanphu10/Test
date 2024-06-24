using user.Repositories.RepoUser;

namespace user.Repositories
{
    public interface IUnitOfWork
    {

        IUserRepository Users { get; }

        Task<int> CompleteAsync();

    }
}
