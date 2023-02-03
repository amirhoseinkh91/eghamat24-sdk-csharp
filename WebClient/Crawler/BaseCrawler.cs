using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebClient.DTOs.Responses;

namespace WebClient.Crawler
{
    public abstract class BaseCrawler<TOut> where TOut: class, new() 
    {
        internal async Task<TOut> CrawlAsync()
        {
            var response = await GetHttpClient().SendAsync(GetRequestMessage());
            if (!response.IsSuccessStatusCode)
            {
                return new TOut();
            }
            var responseContent = await response.Content.ReadAsStringAsync();
            var finalResult = JsonConvert.DeserializeObject<TOut>(responseContent);
            return finalResult ?? new TOut();
        }
        protected abstract HttpRequestMessage GetRequestMessage();
        protected abstract HttpClient GetHttpClient();
    }
}