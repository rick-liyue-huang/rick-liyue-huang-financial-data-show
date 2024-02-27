using Microsoft.EntityFrameworkCore;
using webAPI.DataConnectionContext;
using webAPI.Dtos.Comment;
using webAPI.Interfaces;
using webAPI.Mappers;
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

    public async Task<Comment> CreateCommentAsync(Comment comment)
    {
      await _context.Comments.AddAsync(comment);
      await _context.SaveChangesAsync();
      return comment;
    }

    public async Task<Comment?> DeleteCommentAsync(int id)
    {
      var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
      if (comment == null)
      {
        return null;
      }
      _context.Comments.Remove(comment);
      await _context.SaveChangesAsync();
      return comment;
    }

    public async Task<Comment?> UpdateCommentAsync(int id, UpdateCommentRequestDto commentDto)
    {
      var commentToUpdate = await _context.Comments.FindAsync(id);
      if (commentToUpdate == null)
      {
        return null;
      }
      commentToUpdate.FromUpdateRequestToComment(commentDto);
      await _context.SaveChangesAsync();
      return commentToUpdate;
    }
  }
}