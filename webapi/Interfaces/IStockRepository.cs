using webapi.Dto.Stock;
using webapi.Helpers;
using webapi.Models;

namespace webapi.Interface
{
  public interface IStockRepository
  {
    Task<List<Stock>> GetAllStocksAsync(QueryObject queryObject);

    Task<Stock?> GetStockByIdAsync(int id);

    Task<Stock> CreateStockAsync(Stock stockDto);

    Task<Stock?> UpdateStockAsync(int Id, UpdateStockRequest stock);

    Task<Stock?> DeleteStockAsync(int Id);

    Task<bool> StockExists(int id);
  }
}
