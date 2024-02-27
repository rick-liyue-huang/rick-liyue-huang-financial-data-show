using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.DataConnectionContext;
using webAPI.Dtos.Stock;
using webAPI.Interfaces;
using webAPI.Mappers;
using webAPI.Models;

namespace webAPI.Controllers
{
  [Route("api/stock")]
  [ApiController]
  public class StockController : ControllerBase
  {
    private readonly ApplicationDBContext _context;
    private readonly IStockRepository _stockRepository;
    public StockController(ApplicationDBContext context, IStockRepository stockRepository)
    {
      _context = context;
      _stockRepository = stockRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetStocks()
    {
      // get all the stocks from the database and convert them to StockDto, here Stocks is 'DbSet<Stock>', so we can use Mapper to convert it to 'StockDto'.
      // var stocks = await _context.Stocks.ToListAsync();

      var stocks = await _stockRepository.GetStocksAsync();
      var stocksDto = stocks.Select(s => s.ToStockDto());
      return Ok(stocksDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingleStockById([FromRoute] int id)
    {

      /*
      var stock = await _context.Stocks.FindAsync(id);
      if (stock == null)
      {
        return NotFound("Stock not found");
      }
      */
      var stock = await _stockRepository.GetStockByIdAsync(id);
      if (stock == null)
      {
        return NotFound("Stock not found");
      }
      return Ok(stock.ToStockDto());
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] CreateStockRequestDto stockDto)
    {
      var stock = stockDto.FromCreateRequestToStock();
      // await _context.Stocks.AddAsync(stock);
      // await _context.SaveChangesAsync();

      await _stockRepository.CreateStockAsync(stock);
      return CreatedAtAction(nameof(GetSingleStockById), new { id = stock.Id }, stock.ToStockDto());
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStock([FromRoute] int id, [FromBody] UpdateStockRequestDto stockDto)
    {
      // var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
      var stock = await _stockRepository.UpdateStockAsync(id, stockDto);
      if (stock == null)
      {
        return NotFound("Stock not found");
      }

      // stock.FromUpdateRequestToStock(stockDto);
      // await _context.SaveChangesAsync();
      return Ok(stock.ToStockDto());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStock([FromRoute] int id)
    {
      // var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
      var stock = await _stockRepository.DeleteStockAsync(id);
      if (stock == null)
      {
        return NotFound("Stock not found");
      }
      // _context.Stocks.Remove(stock);
      // await _context.SaveChangesAsync();
      return NoContent();
    }
  }
}