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
    private readonly IFileHandlerService _fileHandlerService;

    public FileController(IFileHandlerService fileHandlerService)
    {
      _fileHandlerService = fileHandlerService;
    }

    [HttpPost("Upload"), Authorize]
    public async Task<IActionResult> UploadAsync(IFormFile file)
    {
      var currentUser = HttpContext.User;
      ClaimsPrincipal claimsPrincipal = HttpContext.User;
      return Ok(_fileHandlerService.Upload(file, claimsPrincipal));
    }

    [HttpGet("GetAllFilesForTheUser"), Authorize]
    public IActionResult GetAllFilesForTheUser()
    {
      var currentUser = HttpContext.User;
      return Ok(_fileHandlerService.GetAllFilesForTheUser(currentUser));
    }

    [HttpPost("Deletefile"), Authorize]
    public IActionResult DeleteFile(string fileName)
    {
      var currentUser = HttpContext.User;
      return Ok(_fileHandlerService.DeleteFile(fileName, currentUser));
    }

    [HttpPost("DownloadFile"), Authorize]
    public async Task<IActionResult> DownloadFile(string fileName)
    {
      var currentUser = HttpContext.User;
      return Ok(_fileHandlerService.DownloadFile(fileName, currentUser));
    }
  }
}
