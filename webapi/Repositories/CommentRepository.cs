
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Repository
{
  public class CommentRepository : ICommentRepository
  {
    private readonly ApplicationDbContext _context;
    public CommentRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<Comment> CreateCommentAsync(Comment comment)
    {
      await _context.Comments.AddAsync(comment);
      await _context.SaveChangesAsync();
      return comment;
    }

    public async Task<Comment?> DeleteCommentAsync(int Id)
    {
      var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == Id);

      if (comment == null)
      {
        return null;
      }
      _context.Comments.Remove(comment);
      await _context.SaveChangesAsync();
      return comment;
    }

    public async Task<List<Comment>> GetAllCommentsAsync()
    {
      return await _context.Comments.ToListAsync();
    }

    public async Task<Comment?> GetCommentByIdAsync(int id)
    {
      return await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Comment?> UpdateCommentAsync(int Id, Comment comment)
    {
      throw new NotImplementedException();
    }
  }
}
