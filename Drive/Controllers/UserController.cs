using Drive.DTO;
using Drive.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Drive.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IAuthService _authService;
    public UserController(IAuthService authService)
    {
      _authService = authService;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegistrationUserDTO user)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var result = await _authService.RegisterUser(user);
      if (result.IsAuthenticated == false)
      {
        return BadRequest(result.ErrorMessage);
      }
      return Ok(new
      {
        UserName = result.Username,
        Email = result.Email,
        Token = result.Token,
        ExpirationOn = result.ExpirationOn,
        Roles = result.Roles
      });
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO user)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var result = await _authService.LoginUser(user);
      if (result.IsAuthenticated == false)
      {
        return BadRequest(result.ErrorMessage);
      }
      return Ok(new
      {
        UserName = result.Username,
        Email = result.Email,
        Token = result.Token,
        ExpirationOn = result.ExpirationOn,
        Roles = result.Roles
      });
    }

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
      //access token from header

      Request.Headers["Authorization"] = string.Empty;
      return Ok();


    }

    [HttpPost("assignrole")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AssignRole(UserToRoleDTO user)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var result = await _authService.AssignRole(user);
      return Ok(result);
    }
    [HttpPost("removerole"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> RemoveRole(UserToRoleDTO user)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var result = await _authService.DeleteRole(user);
      return Ok(result);
    }
    //[HttpPost("updaterole"), Authorize(Roles = "Admin")]
    //public async Task<IActionResult> Update(UpdateRoleForUserDTO user)
    //{
    //  if (!ModelState.IsValid) return BadRequest(ModelState);
    //  var result = await _authService.UpdateRole(user);
    //  return Ok(result);
    //}
    [HttpGet("getroles/{userId}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetRoles(string userId)
    {
      var result = await _authService.GetRoles(userId);
      return Ok(result);
    }

  }
}
