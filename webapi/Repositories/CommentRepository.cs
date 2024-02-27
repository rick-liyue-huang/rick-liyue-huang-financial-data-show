using Microsoft.EntityFrameworkCore;
using webAPI.DataConnectionContext;
using webAPI.Dtos.Comment;
using webAPI.Interfaces;
using webAPI.Models;

namespace webAPI.Repositories
{
  public class CommentRepository : ICommentRepository
  {
    private readonly ApplicationDBContext _context;
    public CommentRepository(ApplicationDBContext context)
    {
      _context = context;
    }

    public async Task<Comment?> GetCommentByIdAsync(int id)
    {
      var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);

      if (comment == null)
      {
        return null;
      }
      return comment;
    }

    public async Task<List<Comment>> GetCommentsAsync()
    {
      return await _context.Comments.ToListAsync();
    }
  }
}