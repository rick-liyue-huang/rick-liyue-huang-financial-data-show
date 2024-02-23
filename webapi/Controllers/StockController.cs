using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Dto.Stock;
using webapi.Mappers;
using webapi.Models;

namespace webapi.Controllers
{
  [Route("api/stock")]
  [ApiController]
  public class StockController : ControllerBase
  {
    private readonly ApplicationDbContext _context;
    public StockController(ApplicationDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
      var stocks = _context.Stocks.ToList().Select(stock => stock.MapToDto());
      return Ok(stocks);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
      var stock = _context.Stocks.Find(id);
      if (stock == null)
      {
        return NotFound();
      }
      return Ok(stock.MapToDto());
    }


    [HttpPost]
    public IActionResult Create([FromBody] CreateStockRequest stockDto) // stockDto is the input from the user, and get the map to the Stock model
    {
      var stock = new Stock
      {
        Symbol = stockDto.Symbol,
        CompanyName = stockDto.CompanyName,
        Purchase = stockDto.Purchase,
        LastDiv = stockDto.LastDiv,
        Industry = stockDto.Industry,
        MarketCap = stockDto.MarketCap,
      };
      _context.Stocks.Add(stock);
      _context.SaveChanges();
      return CreatedAtAction(nameof(GetById), new { id = stock.Id }, stock.MapToDto());
    }
  }
}