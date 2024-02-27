using System.ComponentModel.DataAnnotations;

namespace webAPI.Dtos.Comment
{
  public class UpdateCommentRequestDto
  {
    [Required]
    [MinLength(3, ErrorMessage = "Title must be at least 3 characters long")]
    [MaxLength(50, ErrorMessage = "Title must be at most 50 characters long")]
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
  }
}