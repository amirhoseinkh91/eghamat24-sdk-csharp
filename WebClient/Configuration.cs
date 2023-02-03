namespace WebClient
{
    public sealed class Configuration
    {
        private readonly string _apiVersion;

        public string ApiVersion => $"api-{_apiVersion}";
        public string BaseUrl { get; }
        public string ApiKey { get; }

        public Configuration(string baseUrl, string apiKey, string apiVersion = "v2")
        {
            BaseUrl = baseUrl;
            ApiKey = apiKey;
            _apiVersion = apiVersion;
        }
    }
}