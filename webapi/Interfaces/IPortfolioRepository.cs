
using webAPI.Models;

namespace webAPI.Interfaces
{
  public interface IPortfolioRepository
  {
    Task<List<Stock>> GetUserPortfolio(WebAppUser user);
  }
}