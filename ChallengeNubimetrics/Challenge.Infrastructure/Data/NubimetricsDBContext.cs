using Challenge.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Challenge.Infrastructure.Data
{
    public partial class NubimetricsDBContext : DbContext
    {
        public NubimetricsDBContext()
        {
        }

        public NubimetricsDBContext(DbContextOptions<NubimetricsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
