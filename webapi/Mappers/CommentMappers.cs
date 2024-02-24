namespace webapi.Mappers
{
  using webapi.Dtos.Comment;
  using webapi.Models;

  public static class CommentMappers
  {
    public static CommentDto MapToDto(this Comment comment)
    {
      return new CommentDto
      {
        Id = comment.Id,
        Title = comment.Title,
        Content = comment.Content,
        CreatedOn = comment.CreatedOn,
        StockId = comment.StockId,
      };
    }

    public static Comment MapToModel(this CreateCommentRequest comment, int stockId)
    {
      return new Comment
      {
        Title = comment.Title,
        Content = comment.Content,
        StockId = stockId,
      };
    }

    public static Comment MapToModel(this UpdateCommentRequest comment)
    {
      return new Comment
      {
        Title = comment.Title,
        Content = comment.Content,
      };
    }

  }
}
