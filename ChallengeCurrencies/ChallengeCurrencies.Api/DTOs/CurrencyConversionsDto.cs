#nullable disable
namespace ChallengeCurrencies.Api.DTOs
{
    public class CurrencyConversionsDto
    {
        public string currency_base { get; set; }
        public string currency_quote { get; set; }
        public double? ratio { get; set; }
        public double? rate { get; set; }
        public double? inv_rate { get; set; }
        public DateTime? creation_date { get; set; }
        public DateTime? valid_until { get; set; }
    }
}
