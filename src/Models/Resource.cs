using Newtonsoft.Json;

namespace SmartRunwayApi.Models
{
    public abstract class Resource
    {
        [JsonProperty(Order = -2)]
        public string Href { get; set; }
    }
}