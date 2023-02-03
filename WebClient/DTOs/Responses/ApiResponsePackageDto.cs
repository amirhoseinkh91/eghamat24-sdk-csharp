using Newtonsoft.Json;

namespace WebClient.DTOs.Responses
{
    public class ApiResponsePackageDto<TResult>
    {
        [JsonProperty("status")] 
        public bool Status { get; set; }
        
        [JsonProperty("message")]
        public string Message { get; set; }
        
        [JsonProperty("Result")]
        public TResult? Result { get; set; }
        
        [JsonProperty("outputType")]
        public string OutputType { get; set; }
        
        [JsonProperty("executionTime")]
        public string ExecutionTime { get; set; }
    }
}