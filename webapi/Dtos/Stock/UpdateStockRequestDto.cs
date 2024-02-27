using System.ComponentModel.DataAnnotations;

namespace webAPI.Dtos.Stock
{
  public class UpdateStockRequestDto
  {
    // data validation
    [Required]
    [MaxLength(12, ErrorMessage = "Symbol must be at most 12 characters long")]
    public string Symbol { get; set; } = string.Empty;
    [Required]
    public string CompanyName { get; set; } = string.Empty;
    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Purchase must be a positive number")]
    public decimal Purchase { get; set; }
    [Required]
    public decimal LastDiv { get; set; }
    [Required]
    public string Industry { get; set; } = string.Empty;
    [Required]
    public long MarketCap { get; set; }
  }
}