using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Models
{
  [Table("Portfolios")]
  public class Portfolio
  {
    public string WebAppUserId { get; set; }
    public int StockId { get; set; }
    public WebAppUser WebAppUser { get; set; }
    public Stock Stock { get; set; }
  }
}
