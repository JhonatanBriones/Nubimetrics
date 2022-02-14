
namespace Challenge.Infrastructure.Interfaces
{
    public interface ISearchService
    {
        Task<object> ShearchByQuery(string query);
    }
}