using System;
using System.Net.Http;
using WebClient.DTOs.Responses;

namespace WebClient.Crawler
{
    internal class HotelsCrawler: BaseCrawler<HotelListResponseDto>
    {
        private readonly Configuration _configuration;
        private readonly string _cityNameEn;

        public HotelsCrawler(Configuration configuration, string cityNameEn)
        {
            _configuration = configuration;
            _cityNameEn = cityNameEn;
        }

        protected override HttpRequestMessage GetRequestMessage()
        {
            var url = $"{_configuration.BaseUrl}/{_configuration.ApiVersion}/{_configuration.ApiKey}/json/hotelLoad" +
                      $"?city={_cityNameEn}";
            return new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                Content = null,
                RequestUri = new Uri(url),
            };
        }

        protected override HttpClient GetHttpClient()
        {
            return new HttpClient();
        }
    }
}