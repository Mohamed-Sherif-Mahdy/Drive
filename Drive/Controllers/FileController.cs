using Drive.PublicClasses;
using Microsoft.AspNetCore.Mvc;

namespace Drive.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FileController : ControllerBase
  {
    [HttpPost]
    public IActionResult Upload(IFormFile file)
    {
      return Ok(new UploadHandler().Upload(file));


    }
  }
}
