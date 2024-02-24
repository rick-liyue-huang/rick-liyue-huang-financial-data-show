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
  }
}
