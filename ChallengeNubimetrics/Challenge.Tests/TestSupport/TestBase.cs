using Challenge.Core.CustomEntities;
using Challenge.Core.Interfaces;
using Challenge.Core.Services;
using Challenge.Infrastructure.Data;
using Challenge.Infrastructure.Repositories;
using Challenge.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Challenge.Tests.TestSupport
{
    public class TestBase
    {
        protected NubimetricsDBContext buildContext(string DBName)
        {
            var options = new DbContextOptionsBuilder<NubimetricsDBContext>()
                .UseInMemoryDatabase(DBName).Options;
            var dbContext = new NubimetricsDBContext(options);
            return dbContext;
        }
        protected UserService buildUserService(NubimetricsDBContext context)
        {
            IOptions<PasswordOptions> options = Options.Create(new PasswordOptions() { Iterations = 10000, KeySize = 32, SaltSize = 16 });
            IPasswordService pwService = new PasswordService(options);
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            return new UserService(unitOfWork, pwService);
        }
    }
}
