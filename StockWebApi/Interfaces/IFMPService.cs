using StockWebApi.Models;

namespace StockWebApi.Interfaces
{
    public interface IFMPService
    {
        Task<Stock> FindStockBySymbolAsync(string symbol);


    }
}
