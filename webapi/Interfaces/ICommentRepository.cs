using webAPI.Dtos.Comment;
using webAPI.Models;

namespace webAPI.Interfaces
{
  public interface ICommentRepository
  {
    Task<List<Comment>> GetCommentsAsync();
    Task<Comment?> GetCommentByIdAsync(int id);
    Task<Comment> CreateCommentAsync(Comment comment);
    Task<Comment?> DeleteCommentAsync(int id);
    Task<Comment?> UpdateCommentAsync(int id, UpdateCommentRequestDto comment);
  }
}
