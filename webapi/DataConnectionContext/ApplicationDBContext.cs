
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.DataConnectionContext
{

  // The ApplicationDBContext class represents a session with the database and can be used to query and save instances of Stock and Comment.
  // before is DbContext, now is IdentityDbContext<WebAppUser>
  public class ApplicationDBContext : IdentityDbContext<WebAppUser>
  {
    public ApplicationDBContext(DbContextOptions options) : base(options)
    {

    }

    // A DbSet can be used to query and save instances of Comment. LINQ queries against a DbSet will be translated into queries against the database.
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Comment> Comments { get; set; }


    // tell identity we will use the role of WebAppUser, and the role of IdentityRole
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      List<IdentityRole> role = new List<IdentityRole>
      {
        new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
        new IdentityRole { Name = "User", NormalizedName = "USER" }
      };
      modelBuilder.Entity<IdentityRole>().HasData(role);
    }
  }
}

// docker run -e "ACCEPT_EULA=1" -e "MSSQL_USER=SA" -e "MSSQL_SA_PASSWORD=SQLConnect1" -e "MSSQL_PID=Developer" -p 1433:1433 -d --name=sql_connect mcr.microsoft.com/azure-sql-edge