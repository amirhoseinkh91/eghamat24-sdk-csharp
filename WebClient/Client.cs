using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebClient.DTOs.Responses;

namespace WebClient
{
    public class Client
    {
        private readonly CrawlerFactory _crawlerFactory;

        public Client(Configuration configuration)
        {
            _crawlerFactory = new CrawlerFactory(configuration);
        }

        public async Task<ApiResponsePackageDto<List<CityResponseDto>>> GetAllCitiesAsync()
        {
            return await _crawlerFactory.CreateAllCitiesCrawler().CrawlAsync();
        }

        public async Task<CommentResponseDto> GetCommentsByHotelAsync(string hotelId, string? city = null)
        {
            var result =  await _crawlerFactory.CreateCommentsCrawler(hotelId, city).CrawlAsync();
            return result.Result?.Comment ?? new CommentResponseDto();
        }

        public async Task<PricesResponseDto> GetPricesByHotelAsync(string hotelId, DateTime checkInDate, int nights)
        {
            return await _crawlerFactory.CreatePriceCrawler(hotelId, checkInDate, nights).CrawlAsync();
        }

        public async Task<HotelListResponseDto> GetHotelsByCityAsync(string cityNameEn)
        {
            return await _crawlerFactory.createHotelsCrawler(cityNameEn).CrawlAsync();
        }
    }
}