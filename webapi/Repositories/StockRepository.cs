using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Dto.Stock;
using webapi.Helpers;
using webapi.Interface;
using webapi.Models;

namespace webapi.Repository
{
  public class StockRepository : IStockRepository
  {
    private readonly ApplicationDbContext _context;
    public StockRepository(ApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<List<Stock>> GetAllStocksAsync(QueryObject queryObject)
    {
      // return await _context.Stocks.Include(c => c.Comments).ToListAsync();
      var stocks = _context.Stocks.Include(s => s.Comments).AsQueryable();

      // Filtering
      if (!string.IsNullOrWhiteSpace(queryObject.CompanyName))
      {
        stocks = stocks.Where(s => s.CompanyName.Contains(queryObject.CompanyName));
      }
      if (!string.IsNullOrWhiteSpace(queryObject.Symbol))
      {
        stocks = stocks.Where(s => s.Symbol.Contains(queryObject.Symbol));
      }


      // Sorting
      if (!string.IsNullOrWhiteSpace(queryObject.SortBy))
      {
        if (queryObject.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
        {
          stocks = queryObject.IsSortDescending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol);
        }
        else if (queryObject.SortBy.Equals("CompanyName", StringComparison.OrdinalIgnoreCase))
        {
          stocks = queryObject.IsSortDescending ? stocks.OrderByDescending(s => s.CompanyName) : stocks.OrderBy(s => s.CompanyName);
        }
      }

      // Pagination
      var skipNumber = (queryObject.PageNumber - 1) * queryObject.PageSize;

      return await stocks.Skip(skipNumber).Take(queryObject.PageSize).ToListAsync();
    }

    public async Task<Stock?> GetStockByIdAsync(int id)
    {
      return await _context.Stocks.Include(s => s.Comments).FirstOrDefaultAsync(item => item.Id == id);
    }

    public async Task<Stock> CreateStockAsync(Stock stock)
    {
      await _context.Stocks.AddAsync(stock);
      await _context.SaveChangesAsync();
      return stock;
    }

    public async Task<Stock?> UpdateStockAsync(int Id, UpdateStockRequest stock)
    {
      var stockToUpdate = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == Id);
      if (stockToUpdate == null)
      {
        return null;
      }
      stockToUpdate.CompanyName = stock.CompanyName;
      stockToUpdate.Symbol = stock.Symbol;
      stockToUpdate.Purchase = stock.Purchase;
      stockToUpdate.LastDiv = stock.LastDiv;
      stockToUpdate.Industry = stock.Industry;
      stockToUpdate.MarketCap = stock.MarketCap;
      await _context.SaveChangesAsync();
      return stockToUpdate;
    }

    public async Task<Stock?> DeleteStockAsync(int Id)
    {
      var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == Id);
      if (stock == null)
      {
        return null;
      }
      _context.Stocks.Remove(stock);
      await _context.SaveChangesAsync();
      return stock;
    }

    public Task<bool> StockExists(int id)
    {
      return _context.Stocks.AnyAsync(e => e.Id == id);
    }

  }
}