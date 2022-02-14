#nullable disable
namespace Challenge.Core.DTOs
{
    public class FilterDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public List<ValueDto> values { get; set; }
    }
}
