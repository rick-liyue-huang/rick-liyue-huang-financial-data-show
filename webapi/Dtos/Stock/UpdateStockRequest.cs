using System.ComponentModel.DataAnnotations;

namespace webapi.Dto.Stock
{
  public class UpdateStockRequest
  {

    [Required]
    public string Symbol { get; set; } = string.Empty;

    [Required]
    public string CompanyName { get; set; } = string.Empty;

    [Required]
    public decimal Purchase { get; set; }

    [Required]
    public decimal LastDiv { get; set; }

    [Required]
    public string Industry { get; set; } = string.Empty;

    [Required]
    public long MarketCap { get; set; }
  }
}