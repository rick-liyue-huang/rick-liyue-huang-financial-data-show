using Microsoft.AspNetCore.Mvc;
using webAPI.DataConnectionContext;
using webAPI.Dtos.Stock;
using webAPI.Mappers;
using webAPI.Models;

namespace webAPI.Controllers
{
  [Route("api/stock")]
  [ApiController]
  public class StockController : ControllerBase
  {
    private readonly ApplicationDBContext _context;
    public StockController(ApplicationDBContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult GetStocks()
    {
      // get all the stocks from the database and convert them to StockDto, here Stocks is 'DbSet<Stock>', so we can use Mapper to convert it to 'StockDto'.
      var stocks = _context.Stocks.ToList().Select(s => s.ToStockDto());
      return Ok(stocks);
    }

    [HttpGet("{id}")]
    public IActionResult GetSingleStockById([FromRoute] int id)
    {
      var stock = _context.Stocks.Find(id);
      if (stock == null)
      {
        return NotFound("Stock not found");
      }
      return Ok(stock.ToStockDto());
    }

    [HttpPost]
    public IActionResult CreatePost([FromBody] CreateStockRequestDto stockDto)
    {
      var stock = stockDto.FromCreateRequestToStock();
      _context.Stocks.Add(stock);
      _context.SaveChanges();
      return CreatedAtAction(nameof(GetSingleStockById), new { id = stock.Id }, stock.ToStockDto());
    }


    [HttpPut("{id}")]
    public IActionResult UpdateStock([FromRoute] int id, [FromBody] UpdateStockRequestDto stockDto)
    {
      var stock = _context.Stocks.FirstOrDefault(x => x.Id == id);
      if (stock == null)
      {
        return NotFound("Stock not found");
      }

      stock.FromUpdateRequestToStock(stockDto);
      _context.SaveChanges();
      return Ok(stock.ToStockDto());
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStock([FromRoute] int id)
    {
      var stock = _context.Stocks.FirstOrDefault(x => x.Id == id);
      if (stock == null)
      {
        return NotFound("Stock not found");
      }
      _context.Stocks.Remove(stock);
      _context.SaveChanges();
      return NoContent();
    }
  }
}