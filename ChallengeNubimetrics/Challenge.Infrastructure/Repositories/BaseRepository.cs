using Challenge.Core.Entities;
using Challenge.Core.Exceptions;
using Challenge.Core.Interfaces;
using Challenge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly NubimetricsDBContext _context;
        protected readonly DbSet<T> _entities;
        public BaseRepository(NubimetricsDBContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
        }
        public async Task Update(T entity)
        {
            await GetById(entity.Id);
            _entities.Update(entity);
        }
        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _context.Remove(entity);

        }
        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }
        public async Task<T> GetById(int id)
        {
            var entity = await _entities.FindAsync(id);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            else
            {
                throw new KeyNotFoundException($"El elemento: {id} no se encuentra registrado en la base de datos");
            }
            return entity;
        }

    }
}
