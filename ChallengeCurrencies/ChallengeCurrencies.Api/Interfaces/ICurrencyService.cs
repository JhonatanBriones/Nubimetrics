using ChallengeCurrencies.Api.Responses;

namespace ChallengeCurrencies.Api.Interfaces
{
    public interface ICurrencyService
    {
        Task<List<AppResponse>> GetCurrencies();
    }
}