using System.ComponentModel.DataAnnotations;

namespace webapi.Dto.Stock
{
  public class CreateStockRequest
  {
    [Required]
    [MaxLength(12, ErrorMessage = "Symbol must be at most 12 characters long")]
    public string Symbol { get; set; } = string.Empty;

    [Required]
    [MaxLength(50, ErrorMessage = "Company Name must be at most 50 characters long")]
    public string CompanyName { get; set; } = string.Empty;

    [Required]
    [Range(0, 1000000000, ErrorMessage = "Purchase must be between 0 and 1000000000")]
    public decimal Purchase { get; set; }

    [Required]
    [Range(0, 1000000000, ErrorMessage = "Last Div must be between 0 and 1000000000")]
    public decimal LastDiv { get; set; }

    [Required]
    [MaxLength(50, ErrorMessage = "Industry must be at most 50 characters long")]
    public string Industry { get; set; } = string.Empty;

    [Required]
    public long MarketCap { get; set; }
  }
}
