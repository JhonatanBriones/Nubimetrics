using ChallengeCurrencies.Api.DTOs;
using ChallengeCurrencies.Api.Interfaces;
using ChallengeCurrencies.Api.Responses;
using Newtonsoft.Json;
using static ChallengeCurrencies.Api.Enum.Enum;
#nullable disable

namespace ChallengeCurrencies.Api.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly HttpClient httpClient;

        public CurrencyService(IHttpClientFactory httpClientFactory)
        {
            this.httpClient = httpClientFactory.CreateClient(nameof(Client.MercadoLibreClient));
        }
        public async Task<List<AppResponse>> GetCurrencies()
        {
            var appResponse = new List<AppResponse>();
            var responseMessage = await httpClient.GetAsync("currencies");
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                appResponse = JsonConvert.DeserializeObject<List<AppResponse>>(content);
            }
            if (appResponse.Count > 0)
            {
                await Parallel.ForEachAsync(appResponse, async (app, _) =>
                {
                    app.todolar = await GetConversion(app.id);
                });
            }
            await WriteCsvAsync(appResponse);
            return appResponse;
        }
        private async Task<CurrencyConversionsDto> GetConversion(string id)
        {
            var currencyDto = new CurrencyConversionsDto();
            var responseMessage = await httpClient.GetAsync($"currency_conversions/search?from={id}&to=USD");
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                currencyDto = JsonConvert.DeserializeObject<CurrencyConversionsDto>(content);
            }
            return currencyDto;
        }
        private async Task WriteCsvAsync(List<AppResponse> appResponses)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var csvFullPath = $"{docPath}/{DateTime.Now.ToString("yyyyMMddHHmmss")}.csv";
            using (var writer = new StreamWriter(csvFullPath))
            {
                await writer.WriteLineAsync(string.Join(",", appResponses.Select(x=>x.todolar.ratio.ToString().Replace(',','.'))));
            }
        }
    }
}
