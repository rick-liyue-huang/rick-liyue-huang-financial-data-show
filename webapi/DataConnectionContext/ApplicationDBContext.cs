
using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.DataConnectionContext
{
  public class ApplicationDBContext : DbContext
  {
    public ApplicationDBContext(DbContextOptions options) : base(options)
    {

    }

    // A DbSet can be used to query and save instances of Comment. LINQ queries against a DbSet will be translated into queries against the database.
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Comment> Comments { get; set; }
  }
}

// docker run -e "ACCEPT_EULA=1" -e "MSSQL_USER=SA" -e "MSSQL_SA_PASSWORD=SQLConnect1" -e "MSSQL_PID=Developer" -p 1433:1433 -d --name=sql_connect mcr.microsoft.com/azure-sql-edge