namespace Drive.PublicClasses
{
  public class UploadHandler
  {
    private readonly long ConvertionNumber = 1024 * 1024;
    private List<string> ValidExtentions = new() { ".jpg", ".png", ".gif", ".txt", ".csv", ".xml", ".json", ".md", ".doc", ".pdf" };
    private int MaxFileSizeInMb = 10;
    public string Upload(IFormFile file)
    {
      if (file == null)
      {
        return "You Have to upload a file..";
      }
      string extension = Path.GetExtension(file.FileName);
      if (!CheekExtention(extension))
      {
        return $"Extention is not Valid you can upload ({string.Join(",", ValidExtentions)})";
      }
      if (!CheekSize(file))
      {
        return $"Maximum size can be {MaxFileSizeInMb}..";
      }
      string FileName = $"{Guid.NewGuid().ToString()}{extension}";
      string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
      using FileStream fileStream = new FileStream(Path.Combine(path, FileName), FileMode.Create);
      file.CopyTo(fileStream);

      return $"Uploading...{file.Name}";

    }
    private bool CheekExtention(string extension)
    {
      if (ValidExtentions.Contains(extension))
      {
        return true;
      }
      return false;
    }
    private bool CheekSize(IFormFile file)
    {
      long fileSizeInBytes = file.Length;
      long ValidSizeInbytes = FromMbTobytes(MaxFileSizeInMb);
      if (ValidSizeInbytes >= fileSizeInBytes)
      {
        return true;
      }
      return false;

    }
    private long FromMbTobytes(long Kb)
    {
      return Kb * ConvertionNumber;
    }


  }
}
