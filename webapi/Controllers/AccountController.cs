
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.Dtos.Account;
using webAPI.Interfaces;
using webAPI.Models;

namespace webAPI.Controllers
{
  [Route("api/account")]
  [ApiController]
  public class AccountController : ControllerBase
  {
    private readonly UserManager<WebAppUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<WebAppUser> _signInManager;
    public AccountController(UserManager<WebAppUser> userManager, ITokenService tokenService, SignInManager<WebAppUser> signInManager)
    {
      _userManager = userManager;
      _tokenService = tokenService;
      _signInManager = signInManager;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto register)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }

        var appUser = new WebAppUser
        {
          UserName = register.UserName,
          Email = register.Email
        };

        var result = await _userManager.CreateAsync(appUser, register.Password);

        if (result.Succeeded)
        {
          var newRole = await _userManager.AddToRoleAsync(appUser, "User");
          if (newRole.Succeeded)
          {
            // return Ok("User created successfully!");
            return Ok(new NewUserDto
            {
              UserName = appUser.UserName,
              Email = appUser.Email,
              Token = _tokenService.CreateToken(appUser)
            });
          }
          else
          {
            return StatusCode(500, newRole.Errors);
          }
        }
        else
        {
          return StatusCode(500, result.Errors);
        }
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto login)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }

        var appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == login.UserName.ToLower());

        if (appUser == null)
        {
          return Unauthorized("Invalid username");
        }

        var result = await _signInManager.CheckPasswordSignInAsync(appUser, login.Password, false);

        if (!result.Succeeded)
        {
          return Unauthorized("Username is not right, or Invalid password");
        }
        return Ok(new NewUserDto
        {
          UserName = appUser.UserName,
          Email = appUser.Email,
          Token = _tokenService.CreateToken(appUser)
        });

      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
  }

}