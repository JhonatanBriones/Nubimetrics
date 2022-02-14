using Newtonsoft.Json;
#nullable disable
namespace Challenge.Infrastructure.Helpers
{
    public static class MapHelper
    {
        public static T MapTo<T>(this Object value)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(value));
        }
    }
}
