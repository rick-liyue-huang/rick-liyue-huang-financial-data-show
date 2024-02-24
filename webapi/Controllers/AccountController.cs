

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webapi.Dtos.Account;
using webapi.Models;

namespace webapi.Controllers
{

  [Route("api/account")]
  [ApiController]
  public class AccountController : ControllerBase
  {
    private readonly UserManager<WebAppUser> _userManager;
    public AccountController(UserManager<WebAppUser> userManager)
    {
      _userManager = userManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }

        var user = new WebAppUser
        {
          UserName = registerDto.Username,
          Email = registerDto.Email
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if (result.Succeeded)
        {
          // match the role to the 'User' role in applicationDBContext
          var roleResult = await _userManager.AddToRoleAsync(user, "User");
          if (roleResult.Succeeded)
          {
            return Ok("User created successfully");
          }
          else
          {
            return StatusCode(500, roleResult.Errors);
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
  }
}