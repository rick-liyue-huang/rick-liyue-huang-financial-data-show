using Microsoft.AspNetCore.Mvc;
using webAPI.DataConnectionContext;
using webAPI.Mappers;

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
  }
}