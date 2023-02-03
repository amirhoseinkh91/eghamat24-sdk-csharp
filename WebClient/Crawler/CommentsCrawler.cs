using System;
using System.Net.Http;
using System.Threading.Tasks;
using WebClient.DTOs.Responses;

namespace WebClient.Crawler
{
    internal class CommentsCrawler: BaseCrawler<ApiResponsePackageDto<HotelLoadResponseDto>>
    {
        private readonly HttpClient _httpClient;
        private readonly Configuration _configuration;
        private readonly string _hotelId;
        private readonly string _cityNameEn;
        
        internal CommentsCrawler(Configuration configuration, string hotelId, string cityNameEn = "Unknown")
        {
            _httpClient = new HttpClient();
            _configuration = configuration;
            _hotelId = hotelId;
            _cityNameEn = cityNameEn;
        }
        protected override HttpRequestMessage GetRequestMessage()
        {
            var url = $"{_configuration.BaseUrl}/{_configuration.ApiVersion}/{_configuration.ApiKey}/json/hotelLoad" +
                      $"?city={_cityNameEn}&id={_hotelId}";
            return new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url)
            };
        }

        protected override HttpClient GetHttpClient()
        {
            return new HttpClient();
        }
    }
}