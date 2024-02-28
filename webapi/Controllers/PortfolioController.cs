
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webAPI.Extensions;
using webAPI.Interfaces;
using webAPI.Models;

namespace webAPI.Controllers
{
  [Route("api/portfolio")]
  [ApiController]
  public class PortfolioController : ControllerBase
  {

    private readonly UserManager<WebAppUser> _userManager;
    private readonly IStockRepository _stockRepository;
    private readonly IPortfolioRepository _portfolioRepository;
    public PortfolioController(UserManager<WebAppUser> userManager, IStockRepository stockRepository, IPortfolioRepository portfolioRepository)
    {
      _userManager = userManager;
      _stockRepository = stockRepository;
      _portfolioRepository = portfolioRepository;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetPortfolio()
    {
      var username = User.GetUsername();
      var user = await _userManager.FindByNameAsync(username);
      var portfolio = await _portfolioRepository.GetUserPortfolio(user);
      return Ok(portfolio);
    }

  }
}