using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.DataConnectionContext;
using webAPI.Dtos.Stock;
using webAPI.Helpers;
using webAPI.Interfaces;
using webAPI.Mappers;
using webAPI.Models;

namespace webAPI.Controllers
{
  [Route("api/stock")]
  [ApiController]
  public class StockController : ControllerBase
  {
    // private readonly ApplicationDBContext _context;
    private readonly IStockRepository _stockRepository;
    public StockController(/*ApplicationDBContext context, */IStockRepository stockRepository)
    {
      // _context = context;
      _stockRepository = stockRepository;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetStocks([FromQuery] QueryObject query)
    {
      // get all the stocks from the database and convert them to StockDto, here Stocks is 'DbSet<Stock>', so we can use Mapper to convert it to 'StockDto'.
      // var stocks = await _context.Stocks.ToListAsync();

      // match with the data validation in Dto
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var stocks = await _stockRepository.GetStocksAsync(query);
      var stocksDto = stocks.Select(s => s.ToStockDto());
      return Ok(stocksDto);
    }

    // data validation
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetSingleStockById([FromRoute] int id)
    {

      /*
      var stock = await _context.Stocks.FindAsync(id);
      if (stock == null)
      {
        return NotFound("Stock not found");
      }
      */

      // match with the data validation in Dto
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
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

      // match with the data validation in Dto
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var stock = stockDto.FromCreateRequestToStock();
      // await _context.Stocks.AddAsync(stock);
      // await _context.SaveChangesAsync();

      await _stockRepository.CreateStockAsync(stock);
      return CreatedAtAction(nameof(GetSingleStockById), new { id = stock.Id }, stock.ToStockDto());
    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateStock([FromRoute] int id, [FromBody] UpdateStockRequestDto stockDto)
    {
      // var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

      // match with the data validation in Dto
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var stock = await _stockRepository.UpdateStockAsync(id, stockDto);
      if (stock == null)
      {
        return NotFound("Stock not found");
      }

      // stock.FromUpdateRequestToStock(stockDto);
      // await _context.SaveChangesAsync();
      return Ok(stock.ToStockDto());
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteStock([FromRoute] int id)
    {
      // var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

      // match with the data validation in Dto
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

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