using Challenge.Core.Entities;

namespace Challenge.Core.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        Task Delete(int id);
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task Update(T entity);
    }
}