using Microsoft.AspNetCore.Mvc;
using webAPI.DataConnectionContext;

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
      var stocks = _context.Stocks.ToList();
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
      return Ok(stock);
    }
  }
}