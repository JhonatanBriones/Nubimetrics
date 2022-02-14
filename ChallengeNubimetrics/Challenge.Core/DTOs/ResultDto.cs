#nullable disable
namespace Challenge.Core.DTOs
{
    public class ResultDto
    {
        public string id { get; set; }
        public string site_id { get; set; }
        public string title { get; set; }
        public double price { get; set; }
        public SellerDto seller { get; set; }
        public string permalink { get; set; }
    }
}
