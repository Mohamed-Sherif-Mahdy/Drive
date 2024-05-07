﻿namespace Drive.Service
{
  public class FileHandlerService : IFileHandlerService
  {
    string Name;
    public FileHandlerService(string name)
    {
      Name = name;
    }
    private readonly long ConvertionNumber = 1024 * 1024;
    private List<string> ValidExtentions = new() { ".jpg", ".png", ".gif", ".txt", ".csv", ".xml", ".json", ".md", ".doc", ".pdf" };
    private int MaxFileSizeInMb = 10;
    public string Upload(IFormFile file)
    {
      if (file == null) return "You Have to upload a file..";

      string extension = Path.GetExtension(file.FileName);
      if (!CheekExtention(extension)) return
      $"Extention is not Valid you can upload ({string.Join(",", ValidExtentions)})";

      if (!CheekSize(file)) return $"Maximum size can be {MaxFileSizeInMb}..";
      if (Exists(file.FileName)) return "File already exists..";

      string FileName = file.FileName;
      bool exists = Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Uploads", Name));

      if (!exists)
        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Uploads", Name));
      string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", Name);
      using FileStream fileStream = new FileStream(Path.Combine(path, FileName), FileMode.Create);
      file.CopyTo(fileStream);

      return $"Uploading...{file.Name}";

    }

    private bool Exists(string fileName)
    {
      List<string> files = GetAllFilesForTheUser();
      return files.Contains(fileName) ? true : false;

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
    public List<string> GetAllFilesForTheUser()
    {
      bool exists = Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Uploads", Name));

      if (!exists)
        return new List<string>();
      string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", Name);
      return Directory.GetFiles(path).ToList();

    }

  }
}