
using Microsoft.CodeAnalysis.CSharp.Syntax;
using webAPI.Dtos.Stock;
using webAPI.Models;

namespace webAPI.Mappers
{
  public static class StockMappers
  {
    public static StockDto ToStockDto(this Stock stock)
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
        Comments = stock.Comments.Select(c => c.ToCommentDto()).ToList()
      };
    }

    public static Stock FromCreateRequestToStock(this CreateStockRequestDto stockDto)
    {
      return new Stock
      {
        Symbol = stockDto.Symbol,
        CompanyName = stockDto.CompanyName,
        Purchase = stockDto.Purchase,
        LastDiv = stockDto.LastDiv,
        Industry = stockDto.Industry,
        MarketCap = stockDto.MarketCap
      };
    }

    public static Stock FromUpdateRequestToStock(this Stock stock, UpdateStockRequestDto stockDto)
    {
      stock.Symbol = stockDto.Symbol;
      stock.CompanyName = stockDto.CompanyName;
      stock.Purchase = stockDto.Purchase;
      stock.LastDiv = stockDto.LastDiv;
      stock.Industry = stockDto.Industry;
      stock.MarketCap = stockDto.MarketCap;
      return stock;
    }
  }
}