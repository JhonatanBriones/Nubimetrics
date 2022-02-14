using Challenge.Core.Entities;
using Challenge.Core.Interfaces;

namespace Challenge.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPasswordService passwordService;

        public UserService(IUnitOfWork unitOfWork, IPasswordService passwordService)
        {
            this.unitOfWork = unitOfWork;
            this.passwordService = passwordService;
        }
        public async Task<User> CreateUser(User user)
        {
            if (user.Password!=null)
            {
                user.Password = passwordService.Hash(user.Password);
            }
            await unitOfWork.UserRepository.AddAsync(user);
            await unitOfWork.SaveChangesAsync();
            return user;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return unitOfWork.UserRepository.GetAll();
        }
        public async Task<User> GetUserByID(int id)
        {
            return await unitOfWork.UserRepository.GetById(id);
        }
        public async Task<bool> Delete(int id)
        {
            await unitOfWork.UserRepository.Delete(id);
            await unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<User> Update(User user)
        {
            var _user = await GetUserByID(user.Id);
            var password = _user.Password;
            if (password != user.Password)
            {
                user.Password = passwordService.Hash(user.Password);
            }
            await unitOfWork.UserRepository.Update(user);
            await unitOfWork.SaveChangesAsync();
            return user;
        }
    }
}
