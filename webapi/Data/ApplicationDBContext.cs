using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Add the models to the database
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Comment> Comments { get; set; }

  }
}
