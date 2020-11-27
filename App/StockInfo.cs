using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace App
{

    class StockInfo
    {
            
        string FINNHUB_API_TOKEN;

        readonly string ROOT_ENDPOINT;

        HttpClient client;


        public StockInfo() {
            FINNHUB_API_TOKEN = Environment.GetEnvironmentVariable("FINNHUB_API_TOKEN");
            client = new HttpClient();
            ROOT_ENDPOINT = "https://finnhub.io/api/v1/";
        }

        private async Task<JObject> getCompanyProfile(string Ticker) {
            
            string url = ROOT_ENDPOINT + "stock/profile2?symbol=" + Ticker + "&token=" + FINNHUB_API_TOKEN;

            Console.WriteLine("Making API Call...");
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string jsonString = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(jsonString);
            return json;

            // Program main = new Program();

            // JObject json = await main.getCompanyProfile("AAPL");
            // Console.WriteLine(json);

        }



    }
}