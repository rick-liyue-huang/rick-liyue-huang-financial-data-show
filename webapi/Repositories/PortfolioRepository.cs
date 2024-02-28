
using Microsoft.EntityFrameworkCore;
using webAPI.DataConnectionContext;
using webAPI.Interfaces;
using webAPI.Models;

namespace webAPI.Repositories
{
  public class PortfolioRepository : IPortfolioRepository
  {

    private readonly ApplicationDBContext _context;
    public PortfolioRepository(ApplicationDBContext context)
    {
      _context = context;
    }
    public async Task<List<Stock>> GetUserPortfolio(WebAppUser user)
    {
      return await _context.Portfolios.Where(x => x.WebAppUserId == user.Id).Select(stock => new Stock
      {
        Id = stock.StockId,
        Symbol = stock.Stock.Symbol,
        CompanyName = stock.Stock.CompanyName,
        Purchase = stock.Stock.Purchase,
        LastDiv = stock.Stock.LastDiv,
        Industry = stock.Stock.Industry,
        MarketCap = stock.Stock.MarketCap,
      }).ToListAsync();
    }
  }
}
