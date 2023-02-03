using Newtonsoft.Json;

namespace WebClient.DTOs.Responses
{
    public class CityResponseDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("nameFa")]
        public string NameFa { get; set; }
        
        [JsonProperty("stateFa")]
        public string StateFa { get; set; }
        
        [JsonProperty("latitude")]
        public string Latitude { get; set; }
        
        [JsonProperty("longitude")]
        public string Longitude { get; set; }
        
        [JsonProperty("hotels")]
        public int HotelsCount { get; set; }
        
        [JsonProperty("onlineHotels")]
        public int OnlineHotelsCount { get; set; }
    }
}