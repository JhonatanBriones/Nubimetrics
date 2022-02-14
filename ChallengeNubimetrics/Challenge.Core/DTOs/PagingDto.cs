#nullable disable
namespace Challenge.Core.DTOs
{
    public class PagingDto
    {
        public int total { get; set; }
        public int primary_results { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
    }
}
