using Microsoft.EntityFrameworkCore;
using StockWebApi.Data;
using StockWebApi.Interfaces;
using StockWebApi.Models;

namespace StockWebApi.Repository
{
    public class PortfolioRepository:IPortfolioRepository
    {
        private readonly AppDbContext _context;

        public PortfolioRepository(AppDbContext context)
        {
            _context=context;


        }

        public async Task<Portfolio> CreateAsync(Portfolio portfolio)
        {
            await _context.Portfolios.AddAsync(portfolio);
            await _context.SaveChangesAsync();
            return portfolio;
           
        }

        public async Task<Portfolio> DeletePortfolio(AppUser user, string symbol)
        {
            var portfolioModel = await _context.Portfolios.FirstOrDefaultAsync(x => x.AppUserId == user.Id && x.Stock.Symbol.ToLower() == symbol.ToLower());
            if (portfolioModel == null)
            {
                return null;
            }

            _context.Portfolios.Remove(portfolioModel);
            await _context.SaveChangesAsync();
            return portfolioModel;


        }

        public async Task<List<Stock>> GetUserPortfolio(AppUser user)
        {
            return await _context.Portfolios.Where(u => u.AppUserId == user.Id)
                   .Select(stock => new Stock
                   {
                       Id = stock.StockId,
                       Symbol = stock.Stock.Symbol,
                       CompanyName = stock.Stock.CompanyName,
                       StockPrice = stock.Stock.StockPrice,
                       Dividend = stock.Stock.Dividend,
                       Industry = stock.Stock.Industry,
                       MarketCap = stock.Stock.MarketCap,
                   }).ToListAsync();
        }


    }
}
