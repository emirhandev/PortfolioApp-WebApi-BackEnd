using StockWebApi.Dtos.Stock;
using StockWebApi.Models;

namespace StockWebApi.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                StockPrice = stockModel.StockPrice,
                Dividend = stockModel.Dividend,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
                Comments = stockModel.Comments.Select(c=>c.ToCommentDto()).ToList() 
               
            };
        }
        public static Stock ToStockFromCreateDto(this CreateStockRequestDto stockDto)
        {
            return new Stock
            {
                Symbol=stockDto.Symbol,
                CompanyName=stockDto.CompanyName,
                StockPrice=stockDto.StockPrice,
                Dividend=stockDto.Dividend,
                Industry=stockDto.Industry,
                MarketCap=stockDto.MarketCap,
                
                

            };
        }
        public static Stock ToStockFromFMP(this FMPStock fmpStock)
        {
            return new Stock
            {
                Symbol = fmpStock.symbol,
                CompanyName = fmpStock.companyName,
                StockPrice = (decimal)fmpStock.price,
                Dividend = (decimal)fmpStock.lastDiv,
                Industry = fmpStock.industry,
                MarketCap = fmpStock.mktCap,



            };
        }



    }
}
