using Challenge.Core.DTOs;
using Challenge.Core.Exceptions;
using Challenge.Infrastructure.Interfaces;
using Newtonsoft.Json;
using static Challenge.Core.Enumerations.Enum;
#nullable disable

namespace Challenge.Infrastructure.Services
{
    public class SearchService : ISearchService
    {
        private readonly HttpClient client;
        public SearchService(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient(nameof(Client.MercadoLibreClient));
        }
        public async Task<Object> ShearchByQuery(string query)
        {
            object result;
            var responseMessage = await client.GetAsync($"sites/MLA/search?q={query}");
            string content = await responseMessage.Content.ReadAsStringAsync();
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new AppException(content);
            }
            result = JsonConvert.DeserializeObject<SiteDto>(content);
            return result;
        }
    }
}
