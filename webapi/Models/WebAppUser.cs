using Microsoft.AspNetCore.Identity;

namespace webAPI.Models
{
  public class WebAppUser : IdentityUser
  {

    // Many to many relationship with Stock
    public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();


  }
}