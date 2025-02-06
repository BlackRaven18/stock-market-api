using dotnet_web_api.DTOs.Stock;
using dotnet_web_api.Interfaces;
using dotnet_web_api.Mappers;
using dotnet_web_api.Models;
using Newtonsoft.Json;

namespace dotnet_web_api.Services
{
    public class FMPService : IFMPService
    {
        private HttpClient _httpClient;
        private IConfiguration _config;

        public FMPService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _config = configuration;    
        }
        public async Task<Stock> FindStockBySymbolAsync(string symbol)
        {
            try
            {
                var apiKey = Environment.GetEnvironmentVariable("FMP_API_KEY");
                var result = await _httpClient
                    .GetAsync($"https://financialmodelingprep.com/api/v3/profile/{symbol.ToUpper()}?apikey={Environment.GetEnvironmentVariable("FMP_API_KEY")}");

                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    var tasks = JsonConvert.DeserializeObject<FMPStock[]>(content);
                    var stock = tasks[0];
                    if(stock != null)
                    {
                        return stock.ToStockFromFMP();
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

            return null;
        }
    }
}
