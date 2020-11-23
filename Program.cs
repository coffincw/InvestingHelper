using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InvestingProject
{
    class Program
    {
        string FINNHUB_API_TOKEN;
        public Program() {
            FINNHUB_API_TOKEN = Environment.GetEnvironmentVariable("FINNHUB_API_TOKEN");
        }

        private async Task getCompanyProfile(string Ticker) {

            string uri = "";
            string url = "https://finnhub.io/api/stock/profile?symbol=" + Ticker + "&token=" + FINNHUB_API_TOKEN;

            var client = new FinnhubClient(FINNHUB_API_TOKEN);
            Console.WriteLine(await client.Stock.GetCompany(Ticker));
            
            // string test = "https://jsonplaceholder.typicode.com/users";

            // Console.WriteLine("Making API Call...");
            // HttpClient req = new HttpClient();
            // var content = await req.GetAsync(test);
            // Console.WriteLine(await content.Content.ReadAsStringAsync());
            // HttpClientHandler handler = new HttpClientHandler()
            // {
            //     AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            // };        
            // HttpClient client = new HttpClient(handler);
            // //client.BaseAddress = new Uri(uri);
            // HttpResponseMessage response = client.GetAsync(url).Result;
            // response.EnsureSuccessStatusCode();
            // string result = response.Content.ReadAsStringAsync().Result;
            // Console.WriteLine("Result: " + result);

        }

        public static async Task Main (string [] args) {
            Program main = new Program();

            await main.getCompanyProfile("AAPL");
            // Console.WriteLine(resp);
        
        }
    }
}