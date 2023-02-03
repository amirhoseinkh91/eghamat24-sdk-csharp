using Newtonsoft.Json;

namespace WebClient.DTOs.Responses
{
    public class HotelLoadResponseDto
    {
        [JsonProperty("PackageDescription")]
        public string[] PackageDescription { get; set; }
        
        [JsonProperty("breakfast")]
        public bool Breakfast { get; set; }
        
        [JsonProperty("comment")]
        public CommentResponseDto Comment { get; set; }
    }
}