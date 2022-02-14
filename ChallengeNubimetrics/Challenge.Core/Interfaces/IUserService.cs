using Challenge.Core.Entities;

namespace Challenge.Core.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
        Task<bool> Delete(int id);
        IEnumerable<User> GetAllUsers();
        Task<User> GetUserByID(int id);
        Task<User> Update(User user);
    }
}