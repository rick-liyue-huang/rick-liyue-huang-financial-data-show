using System.ComponentModel.DataAnnotations;

namespace webapi.Dtos.Comment
{
  public class UpdateCommentRequest
  {
    [Required]
    [MinLength(3, ErrorMessage = "Title must be at least 3 characters long")]
    [MaxLength(50, ErrorMessage = "Title must be at most 50 characters long")]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Content { get; set; } = string.Empty;

  }
}