using webAPI.Dtos.Comment;
using webAPI.Models;

namespace webAPI.Interfaces
{
  public interface ICommentRepository
  {
    Task<List<Comment>> GetCommentsAsync();
    Task<Comment?> GetCommentByIdAsync(int id);
  }
}
