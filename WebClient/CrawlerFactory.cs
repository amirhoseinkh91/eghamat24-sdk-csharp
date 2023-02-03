using System;
using WebClient.Crawler;

namespace WebClient
{
    internal class CrawlerFactory
    {
        private readonly Configuration _configuration;
        internal CrawlerFactory(Configuration configuration)
        {
            _configuration = configuration;
        }
        internal AllCitiesCrawler CreateAllCitiesCrawler()
        {
            return new AllCitiesCrawler(_configuration);
        }

        internal CommentsCrawler CreateCommentsCrawler(string hotelId, string? city)
        {
            return city != null ? new CommentsCrawler(_configuration,hotelId, city ) : new CommentsCrawler(_configuration,hotelId);
        }

        internal PriceByHotelCrawler CreatePriceCrawler(string hotelId, DateTime checkInDate, int nights = 1)
        {
            return new PriceByHotelCrawler(_configuration, hotelId, checkInDate, nights);
        }

        internal HotelsCrawler createHotelsCrawler(string cityNameEn)
        {
            return new HotelsCrawler(_configuration, cityNameEn);
        }
    }
}