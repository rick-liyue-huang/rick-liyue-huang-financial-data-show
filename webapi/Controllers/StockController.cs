using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Dto.Stock;
using webapi.Interface;
using webapi.Mappers;
using webapi.Models;

namespace webapi.Controllers
{
  [Route("api/stock")]
  [ApiController]
  public class StockController : ControllerBase
  {
    private readonly ApplicationDbContext _context;
    private readonly IStockRepository _stockRepository;
    public StockController(ApplicationDbContext context, IStockRepository stockRepository)
    {
      _context = context;
      _stockRepository = stockRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      // var stocks = await _context.Stocks.ToListAsync();
      var stocks = await _stockRepository.GetAllStocksAsync();

      var stockDto = stocks.Select(stock => stock.MapToDto());
      return Ok(stockDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      // var stock = await _context.Stocks.FindAsync(id);
      var stock = await _stockRepository.GetStockByIdAsync(id);
      if (stock == null)
      {
        return NotFound();
      }
      return Ok(stock.MapToDto());
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStockRequest stockDto) // stockDto is the input from the user, and get the map to the Stock model
    {
      var stock = stockDto.MapToModel();
      // await _context.Stocks.AddAsync(stock);
      // await _context.SaveChangesAsync();
      await _stockRepository.CreateStockAsync(stock);
      return CreatedAtAction(nameof(GetById), new { id = stock.Id }, stock.MapToDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequest stockDto)
    {
      // var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
      var stock = await _stockRepository.UpdateStockAsync(id, stockDto);
      if (stock == null)
      {
        return NotFound();
      }
      // stock.Symbol = stockDto.Symbol;
      // stock.CompanyName = stockDto.CompanyName;
      // stock.Purchase = stockDto.Purchase;
      // stock.LastDiv = stockDto.LastDiv;
      // stock.Industry = stockDto.Industry;
      // stock.MarketCap = stockDto.MarketCap;
      await _context.SaveChangesAsync();
      return Ok(stock.MapToDto());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      // var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
      var stock = await _stockRepository.DeleteStockAsync(id);
      if (stock == null)
      {
        return NotFound();
      }
      // _context.Stocks.Remove(stock);
      // await _context.SaveChangesAsync();
      return NoContent();
    }
  }
}