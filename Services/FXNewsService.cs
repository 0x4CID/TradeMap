using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using TradeMap.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace TradeMap.Services
{
    public class FXNewsService
    {
        public async Task<FXNewsModel[]> GetNews()
        {
            string url = "https://nfs.faireconomy.media/ff_calendar_thisweek.json";

            using var client = new HttpClient();
            
            var results = await client.GetStringAsync(url);

            var news = JsonConvert.DeserializeObject<FXNewsModel[]>(results);

            return news;

        }
    }
}

