#nullable disable

namespace Challenge.Core.DTOs
{
    public class SiteDto
    {
        public string site_id { get; set; }
        public string country_default_time_zone { get; set; }
        public string query { get; set; }
        public PagingDto paging { get; set; }
        public List<ResultDto> results { get; set; }
        public SortDto sort { get; set; }
        public List<AvailableSortDto> available_sorts { get; set; }
        public List<FilterDto> filters { get; set; }
        public List<AvailableFilterDto> available_filters { get; set; }

    }
}
