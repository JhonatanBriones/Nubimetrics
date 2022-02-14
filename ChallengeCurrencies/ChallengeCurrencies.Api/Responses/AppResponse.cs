#nullable disable
using ChallengeCurrencies.Api.DTOs;

namespace ChallengeCurrencies.Api.Responses
{
    public class AppResponse
    {
        public string id { get; set; }
        public string symbol { get; set; }
        public string description { get; set; }
        public int decimal_places { get; set; }
        public CurrencyConversionsDto todolar { get; set; }

    }
}
