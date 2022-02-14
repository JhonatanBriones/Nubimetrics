#nullable disable

namespace Challenge.Core.DTOs
{
    public class ValueDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<PathFromRootDto> path_from_root { get; set; }
        public int results { get; set; }
    }
}
