using System.Net.Http.Headers;
using TradeMap.Models;

namespace TradeMap.Services
{
    public class RatesStreamingService
    {
        string AccountId;
        string ApiKey; 
        string Url;
        string baseUrl;
        public RatesStreamingService()
        {
            this.AccountId = Environment.GetEnvironmentVariable("OANDA-DEMO-ACCOUNT-NUMBER");
            this.baseUrl = $"https://api-fxpractice.oanda.com/v3/";
            this.Url = $"https://stream-fxpractice.oanda.com/v3/accounts/{this.AccountId}/pricing/stream";
            
            this.ApiKey = Environment.GetEnvironmentVariable("OANDA-DEMO-API");
        }

        public async void ChooseInstruments(string pair)
        {
            this.Url = $"{this.Url}?instruments={pair}";
           
            

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.ApiKey);
            client.GetStreamAsync(Url).Result.CopyTo(Console.OpenStandardOutput());

        }

        public async void Authenticate()
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.ApiKey);
            var result = await client.GetAsync($"{this.baseUrl}accounts");
            Console.WriteLine($"Status Code: {result.StatusCode}");
        }
    }
}
