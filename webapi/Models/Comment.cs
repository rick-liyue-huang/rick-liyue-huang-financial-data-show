using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Models
{

  // identify the table name of the table 'Comments'
  [Table("Comments")]
  public class Comment
  {
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
    // navigation to the Stock class
    public int? StockId { get; set; }

    public Stock? Stock { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.Now;
  }
}
