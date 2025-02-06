using dotnet_web_api.Models;

namespace dotnet_web_api.Interfaces
{
    public interface IFMPService
    {
        Task<Stock> FindStockBySymbolAsync(string symbol);
    }
}
