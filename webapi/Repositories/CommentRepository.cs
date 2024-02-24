
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
    public async Task<List<Comment>> GetAllCommentsAsync()
    {
      return await _context.Comments.ToListAsync();
    }

    public async Task<Comment?> GetCommentByIdAsync(int id)
    {
      return await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
    }
  }
}
