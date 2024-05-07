using Drive.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Drive.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FileController : ControllerBase
  {
    [HttpPost("Upload"), Authorize]
    public async Task<IActionResult> UploadAsync(IFormFile file)
    {
      //get the user name from the token
      string Name = string.Empty;
      var currentUser = HttpContext.User;
      ClaimsPrincipal claimsPrincipal = HttpContext.User;
      //string userId = currentUser.Claims.FirstOrDefault(x => x.Type == "uid").Value;


      return Ok(new FileHandlerService(claimsPrincipal).Upload(file));


    }

    [HttpGet("GetAllFilesForTheUser"), Authorize]
    public IActionResult GetAllFilesForTheUser()
    {
      //get the user name from the token
      string Name = string.Empty;
      var currentUser = HttpContext.User;
      return Ok(new FileHandlerService(currentUser).GetAllFilesForTheUser());
    }
    [HttpPost("Deletefile"), Authorize]
    public IActionResult DeleteFile(string fileName)
    {
      //get the user name from the token
      string Name = string.Empty;
      var currentUser = HttpContext.User;
      return Ok(new FileHandlerService(currentUser).DeleteFile(fileName));
    }
  }
}
