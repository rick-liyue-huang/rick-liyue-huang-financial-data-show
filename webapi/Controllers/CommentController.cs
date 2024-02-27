using Microsoft.AspNetCore.Mvc;
using webAPI.Dtos.Comment;
using webAPI.Interfaces;
using webAPI.Mappers;
using webAPI.Models;

namespace webAPI.Controllers
{
  [Route("api/comment")]
  [ApiController]
  public class CommentController : ControllerBase
  {
    private readonly ICommentRepository _commentRepository;
    private readonly IStockRepository _stockRepository;
    public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository)
    {
      _commentRepository = commentRepository;
      _stockRepository = stockRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Comment>>> GetComments()
    {
      var comments = await _commentRepository.GetCommentsAsync();
      var commentDto = comments.Select(c => c.ToCommentDto());
      return Ok(commentDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Comment>> GetSingleCommentById([FromRoute] int id)
    {
      var comment = await _commentRepository.GetCommentByIdAsync(id);
      if (comment == null)
      {
        return NotFound("Comment not found");
      }
      return Ok(comment.ToCommentDto());
    }


    [HttpPost("{stockId}")]
    public async Task<ActionResult<Comment>> CreateComment([FromRoute] int stockId, [FromBody] CreateCommentRequestDto commentDto)
    {

      if (!await _stockRepository.StockExists(stockId))
      {
        return BadRequest("Stock not found");
      }

      var comment = commentDto.FromCreateRequestToComment(stockId);
      await _commentRepository.CreateCommentAsync(comment);

      return CreatedAtAction(nameof(GetSingleCommentById), new { id = comment.Id }, comment.ToCommentDto());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteComment([FromRoute] int id)
    {
      var comment = await _commentRepository.DeleteCommentAsync(id);
      if (comment == null)
      {
        return NotFound("Comment not found");
      }
      return Ok(comment.ToCommentDto());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Comment>> UpdateComment([FromRoute] int id, [FromBody] UpdateCommentRequestDto commentDto)
    {
      var comment = await _commentRepository.UpdateCommentAsync(id, commentDto);
      if (comment == null)
      {
        return NotFound("Comment not found");
      }
      return Ok(comment.ToCommentDto());
    }

  }
}