namespace Drive.Service
{
  public interface IFileHandlerService
  {
    public string Upload(IFormFile file);
    public List<string> GetAllFilesForTheUser();

  }
}
