using AutoMapper;
using dotnet_web_api.DTOs.Stock;
using dotnet_web_api.Interfaces;
using dotnet_web_api.Models;
using Newtonsoft.Json;

namespace dotnet_web_api.Services
{
    public class FMPService : IFMPService
    {
        private HttpClient _httpClient;
        private readonly IMapper _mapper;

        public FMPService(HttpClient httpClient, IMapper mapper, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _mapper = mapper; 
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
                    var stockFMP = tasks[0];
                    if(stockFMP != null)
                    {
                        var stock = _mapper.Map<Stock>(stockFMP);
                        return stock;
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
