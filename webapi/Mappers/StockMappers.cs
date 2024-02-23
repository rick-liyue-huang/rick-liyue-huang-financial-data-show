using webapi.Dto.Stock;
using webapi.Models;

namespace webapi.Mappers
{
  // This class is used to map the Stock model to the StockDto, here we get the Stock model and map it to the StockDto
  public static class StockMappers
  {
    public static StockDto MapToDto(this Stock stock)
    {
      return new StockDto
      {
        Id = stock.Id,
        Symbol = stock.Symbol,
        CompanyName = stock.CompanyName,
        Purchase = stock.Purchase,
        LastDiv = stock.LastDiv,
        Industry = stock.Industry,
        MarketCap = stock.MarketCap,
      };
    }

    // This class is used to map the CreateStockRequest to the Stock model, here we get the CreateStockRequest and map it to the Stock model
    public static Stock MapToModel(this CreateStockRequest stockDto)
    {
      return new Stock
      {
        Symbol = stockDto.Symbol,
        CompanyName = stockDto.CompanyName,
        Purchase = stockDto.Purchase,
        LastDiv = stockDto.LastDiv,
        Industry = stockDto.Industry,
        MarketCap = stockDto.MarketCap,
      };
    }
  }
}
