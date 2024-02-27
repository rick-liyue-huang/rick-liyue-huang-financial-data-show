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
    public CommentController(ICommentRepository commentRepository)
    {
      _commentRepository = commentRepository;
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

  }
}