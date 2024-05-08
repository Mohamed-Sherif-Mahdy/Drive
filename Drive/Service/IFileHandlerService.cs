using System.Security.Claims;

namespace Drive.Service
{
    public interface IFileHandlerService
    {
        public string Upload(IFormFile file, ClaimsPrincipal claimsPrincipal);
        public List<string> GetAllFilesForTheUser(ClaimsPrincipal claimsPrincipal);
        public string DeleteFile(string fileName, ClaimsPrincipal claimsPrincipal);
    }
}
