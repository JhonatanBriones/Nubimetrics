using Challenge.Core.Entities;

namespace Challenge.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IBaseRepository<User> UserRepository { get; }

        void Dispose();
        void SaveChanges();
        Task SaveChangesAsync();
    }
}