using webapi.Models;

namespace webapi.Interfaces
{
  public interface ICommentRepository
  {
    Task<List<Comment>> GetAllCommentsAsync();

    Task<Comment?> GetCommentByIdAsync(int id);

    Task<Comment> CreateCommentAsync(Comment commentDto);

    Task<Comment?> UpdateCommentAsync(int Id, Comment comment);

    Task<Comment?> DeleteCommentAsync(int Id);
  }
}
