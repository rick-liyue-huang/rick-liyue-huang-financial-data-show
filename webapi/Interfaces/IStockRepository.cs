
using webAPI.Dtos.Stock;
using webAPI.Helpers;
using webAPI.Models;

namespace webAPI.Interfaces
{
  public interface IStockRepository
  {
    Task<List<Stock>> GetStocksAsync(QueryObject query);
    Task<Stock?> GetStockByIdAsync(int id);
    Task<Stock> CreateStockAsync(Stock stock);
    Task<Stock?> UpdateStockAsync(int id, UpdateStockRequestDto stockDto);
    Task<Stock?> DeleteStockAsync(int id);
    Task<bool> StockExists(int id);
  }
}