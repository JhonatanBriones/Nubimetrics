using Challenge.Core.Entities;
using Challenge.Core.Interfaces;
using Challenge.Infrastructure.Data;
#nullable disable

namespace Challenge.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NubimetricsDBContext context;
        private readonly IBaseRepository<User> userRepository;
        public UnitOfWork(NubimetricsDBContext context)
        {
            this.context = context;
        }
        public IBaseRepository<User> UserRepository => userRepository ?? new BaseRepository<User>(context);
        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
