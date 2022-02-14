using Challenge.Infrastructure.Helpers;
using Challenge.Infrastructure.Interfaces;
using static Challenge.Core.Enumerations.Enum;

namespace Challenge.Infrastructure.Services
{
    public class CountryService : ICountryService
    {
        private readonly HttpClient client;
        public CountryService(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient(nameof(Client.MercadoLibreClient));
        }
        public async Task<Object> GetCountriesByCode(string code)
        {
            var businnesRule = code.ToUpper().Equals(nameof(rejectedCodes.CO)) || code.ToUpper().Equals(nameof(rejectedCodes.BR));
            if (businnesRule)
            {
                throw new UnauthorizedAccessException("Regla de negocio");
            }
            var responseMessage = await client.GetAsync($"classified_locations/countries/{code.ToUpper()}");
            var result = await ResponseMessage.ToObject(responseMessage);
            return result;
        }

    }
}
