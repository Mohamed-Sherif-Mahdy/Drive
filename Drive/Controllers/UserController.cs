using Drive.DTO;
using Drive.Service;
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
      return Ok(result);
    }
  }
}
