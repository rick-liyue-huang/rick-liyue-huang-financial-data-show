using Microsoft.EntityFrameworkCore;
using webAPI.DataConnectionContext;
using webAPI.Dtos.Stock;
using webAPI.Interfaces;
using webAPI.Models;
using webAPI.Mappers;
using webAPI.Helpers;

namespace webAPI.Repositories
{
  public class StockRepository : IStockRepository
  {
    private readonly ApplicationDBContext _context;
    public StockRepository(ApplicationDBContext context)
    {
      _context = context;
    }
    public async Task<Stock> CreateStockAsync(Stock stock)
    {
      await _context.Stocks.AddAsync(stock);
      await _context.SaveChangesAsync();
      return stock;
    }

    public async Task<Stock?> DeleteStockAsync(int id)
    {
      var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
      if (stock == null)
      {
        return null;
      }
      _context.Stocks.Remove(stock);
      await _context.SaveChangesAsync();
      return stock;
    }

    public async Task<Stock?> GetStockByIdAsync(int id)
    {
      return await _context.Stocks.Include(s => s.Comments).FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<List<Stock>> GetStocksAsync(QueryObject query)
    {
      // get all the stocks from the database by using 'EntityFrameworkCore' and 'ToListAsync' method.
      // return await _context.Stocks.Include(s => s.Comments).ToListAsync();

      var stocks = _context.Stocks.Include(s => s.Comments).AsQueryable();
      if (!string.IsNullOrWhiteSpace(query.CompanyName))
      {
        stocks = stocks.Where(s => s.CompanyName.Contains(query.CompanyName));
      }

      if (!string.IsNullOrWhiteSpace(query.Symbol))
      {
        stocks = stocks.Where(s => s.Symbol.Contains(query.Symbol));
      }

      return await stocks.ToListAsync();

    }

    public Task<bool> StockExists(int id)
    {
      return _context.Stocks.AnyAsync(e => e.Id == id);
    }

    public async Task<Stock?> UpdateStockAsync(int id, UpdateStockRequestDto stockDto)
    {
      var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
      if (stock == null)
      {
        return null;
      }

      stock.FromUpdateRequestToStock(stockDto);
      await _context.SaveChangesAsync();
      return stock;
    }
  }
}