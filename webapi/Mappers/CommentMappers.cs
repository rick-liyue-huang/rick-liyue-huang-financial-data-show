
using webAPI.Dtos.Comment;
using webAPI.Models;

namespace webAPI.Mappers
{
  public static class CommentMappers
  {
    public static CommentDto ToCommentDto(this Comment comment)
    {
      return new CommentDto
      {
        Id = comment.Id,
        Title = comment.Title,
        Content = comment.Content,
        StockId = comment.StockId,
        CreatedOn = comment.CreatedOn
      };
    }

    public static Comment FromCreateRequestToComment(this CreateCommentRequestDto commentDto, int stockId)
    {
      return new Comment
      {
        Title = commentDto.Title,
        Content = commentDto.Content,
        StockId = stockId
      };
    }

    public static Comment FromUpdateRequestToComment(this Comment comment, UpdateCommentRequestDto commentDto)
    {
      comment.Title = commentDto.Title;
      comment.Content = commentDto.Content;
      return comment;
    }
  }
}