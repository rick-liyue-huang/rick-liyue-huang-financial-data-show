using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Dtos.Comment;
using webapi.Interface;
using webapi.Interfaces;
using webapi.Mappers;

namespace webapi.Controllers
{

  [Route("api/comment")]
  [ApiController]
  public class CommentController : ControllerBase
  {
    private readonly ApplicationDbContext _context;
    private readonly ICommentRepository _commentRepository;
    private readonly IStockRepository _stockRepository;
    public CommentController(ApplicationDbContext context, ICommentRepository commentRepository, IStockRepository stockRepository)
    {
      _context = context;
      _commentRepository = commentRepository;
      _stockRepository = stockRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      // var comments = await _context.Comments.ToListAsync();
      var comments = await _commentRepository.GetAllCommentsAsync();

      var commentDto = comments.Select(comment => comment.MapToDto());
      return Ok(commentDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      // var comment = await _context.Comments.FindAsync(id);
      var comment = await _commentRepository.GetCommentByIdAsync(id);
      if (comment == null)
      {
        return NotFound();
      }
      return Ok(comment.MapToDto());
    }

    [HttpPost("{stockId}")]
    public async Task<IActionResult> Create([FromRoute] int stockId, [FromBody] CreateCommentRequest commentDto) // commentDto is the input from the user, and get the map to the Comment model
    {
      if (!await _stockRepository.StockExists(stockId))
      {
        return BadRequest("Stock does not exist");
      }

      var comment = commentDto.MapToModel(stockId);
      await _commentRepository.CreateCommentAsync(comment);
      return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment.MapToDto());

    }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequest commentDto)
    // {
    //   // var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
    //   var comment = await _commentRepository.UpdateCommentAsync(id, commentDto);
    //   if (comment == null)
    //   {
    //     return NotFound();
    //   }
    //   // comment.Content = commentDto.Content;
    //   // comment.StockId = commentDto.StockId;
    //   // await _context.SaveChangesAsync();
    //   return Ok(comment.MapToDto());
    // }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      // var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
      var comment = await _commentRepository.DeleteCommentAsync(id);
      if (comment == null)
      {
        return NotFound();
      }
      // _context.Comments.Remove(comment);
      // await _context.SaveChangesAsync();
      return Ok(comment.MapToDto());
    }
  }
}