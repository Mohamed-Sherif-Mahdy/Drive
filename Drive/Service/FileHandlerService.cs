﻿using System.Security.Claims;
using Drive.Repository;

namespace Drive.Service
{
    public class FileHandlerService : IFileHandlerService
    {
        IRepository<Modles.File> _fileRepository;
        IRepository<Modles.User> _userRepository;

        public FileHandlerService(
            IRepository<Modles.File> fileRepository,
            IRepository<Modles.User> userRepository
        )
        {
            _fileRepository = fileRepository;
            _userRepository = userRepository;
        }

        private readonly long ConvertionNumber = 1024 * 1024;
        private List<string> ValidExtentions =
            new()
            {
                ".jpg",
                ".png",
                ".gif",
                ".txt",
                ".csv",
                ".xml",
                ".json",
                ".md",
                ".doc",
                ".pdf"
            };
        private int MaxFileSizeInMb = 10;

        public string Upload(IFormFile file, ClaimsPrincipal claimsPrincipal)
        {
            if (file == null)
                return "You Have to upload a file..";

            string extension = Path.GetExtension(file.FileName);
            if (!CheekExtention(extension))
                return $"Extention is not Valid you can upload ({string.Join(",", ValidExtentions)})";

            if (!CheekSize(file))
                return $"Maximum size can be {MaxFileSizeInMb}..";
            if (Exists(file.FileName, claimsPrincipal))
                return "File already exists..";
            string Name = claimsPrincipal
                .Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)
                .Value;

            string FileName = file.FileName;
            bool exists = Directory.Exists(
                Path.Combine(Directory.GetCurrentDirectory(), "Uploads", Name)
            );

            if (!exists)
                Directory.CreateDirectory(
                    Path.Combine(Directory.GetCurrentDirectory(), "Uploads", Name)
                );
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", Name);
            using FileStream fileStream = new FileStream(
                Path.Combine(path, FileName),
                FileMode.Create
            );
            file.CopyTo(fileStream);

            //add in the database data about the file
            _fileRepository.Add(
                new Modles.File
                {
                    UserId = Name,
                    FileName = FileName,
                    FilePath = Path.Combine(path, FileName),
                    FileId = Guid.NewGuid().ToString()
                }
            );

            return $"Uploading...{file.Name}";
        }

        private bool Exists(string fileName, ClaimsPrincipal claimsPrincipal)
        {
            List<string> files = GetAllFilesForTheUser(claimsPrincipal);
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

        public List<string> GetAllFilesForTheUser(ClaimsPrincipal claimsPrincipal)
        {
            string id = claimsPrincipal
                .Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)
                .Value;

            bool exists = Directory.Exists(
                Path.Combine(Directory.GetCurrentDirectory(), "Uploads", id)
            );

            if (!exists)
                return new List<string>();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", id);
            List<string> Names = new List<string>();

            foreach (string file in Directory.GetFiles(path).ToList())
            {
                Names.Add(file.Split(Path.DirectorySeparatorChar).Last());
            }

            return Names;
        }

        public string DeleteFile(string fileName, ClaimsPrincipal claimsPrincipal)
        {
            string Name = claimsPrincipal
                .Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)
                .Value;

            List<string> files = GetAllFilesForTheUser(claimsPrincipal);
            if (files.Contains(fileName))
            {
                string path = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "Uploads",
                    Name,
                    fileName
                );
                File.Delete(path);
                _fileRepository.Delete(
                    _fileRepository.GetAll().FirstOrDefault(x => x.FileName == fileName)
                );
                return $"{fileName} is deleted..";
            }
            return $"{fileName} is not found..";
        }

        public async Task<string> DownloadFile(string fileName, ClaimsPrincipal currentUser)
        {
            if (!Exists(fileName, currentUser))
                return "You do NOT have this file..";
            string Name = currentUser
                .Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)
                .Value;

            bool exists = Directory.Exists(
                Path.Combine(Directory.GetCurrentDirectory(), "Downloads", Name)
            );

            if (!exists)
                Directory.CreateDirectory(
                    Path.Combine(Directory.GetCurrentDirectory(), "Downloads", Name)
                );

            string filePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Uploads",
                Name,
                fileName
            );

            try
            {
                byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);

                await File.WriteAllBytesAsync(
                    path: Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "Downloads",
                        Name,
                        fileName
                    ),
                    fileBytes
                );
            }
            catch (Exception ex)
            {
                return $"Internal server error: {ex.Message}";
            }

            return "Done";
        }
    }
}
