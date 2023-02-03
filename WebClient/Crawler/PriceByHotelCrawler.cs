using System;
using System.Net.Http;
using WebClient.DTOs.Responses;
using WebClient.Utils;

namespace WebClient.Crawler
{
    internal class PriceByHotelCrawler : BaseCrawler<PricesResponseDto>
    {
        private readonly Configuration _configuration;
        private readonly string _hotelId;
        private readonly DateTime _checkInDate;
        private readonly int _nights;
        
        internal PriceByHotelCrawler(
            Configuration configuration,
            string hotelId,
            DateTime checkInDate,
            int nights)
        {
            _configuration = configuration;
            _hotelId = hotelId;
            _checkInDate = checkInDate;
            _nights = nights;
        }

        protected override HttpRequestMessage GetRequestMessage()
        {
            var url = $"{_configuration.BaseUrl}/{_configuration.ApiVersion}/{_configuration.ApiKey}/json/hotelPrice" +
                      $"?hotel={_hotelId}&inDate={_checkInDate.ToJalaliDate("-")[2..]}&numberOfNights={_nights}";
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