using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebClient.DTOs.Responses;

namespace WebClient.Crawler
{
    internal class AllCitiesCrawler: BaseCrawler<ApiResponsePackageDto<List<CityResponseDto>>>
    {
        private readonly Configuration _configuration;
        internal AllCitiesCrawler(Configuration configuration)
        {
            _configuration = configuration;
        }

        protected override HttpRequestMessage GetRequestMessage()
        {
            var url = $"{_configuration.BaseUrl}/{_configuration.ApiVersion}/{_configuration.ApiKey}/json/cityLoad";
            return new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
            };
        }

        protected override HttpClient GetHttpClient()
        {
            return new HttpClient();
        }
    }
}