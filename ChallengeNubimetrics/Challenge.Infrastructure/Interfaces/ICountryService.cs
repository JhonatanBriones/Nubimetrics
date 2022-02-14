
namespace Challenge.Infrastructure.Interfaces
{
    public interface ICountryService
    {
        Task<object> GetCountriesByCode(string code);
    }
}