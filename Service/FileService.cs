using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

namespace MovieWeb.Service
{
    public class FileService : IFileService
    {
        private IWebHostEnvironment _environment;
        string _imageFolderPath = string.Empty;
        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
            _imageFolderPath = Path.Combine(_environment.WebRootPath, "images");
        }
        public IFormFile GetFile(string fileName)
        {
            var path = Path.Combine(_imageFolderPath, fileName);
            if (File.Exists(path))
            {
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    return new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name));
                }
            }
            return null;
        }
        public void UploadFile(IFormFile file)
        {
            if (!Directory.Exists(_imageFolderPath))
            {
                Directory.CreateDirectory(_imageFolderPath);
            }
            var filePath = Path.Combine(_imageFolderPath, file.FileName);

            if (!File.Exists(filePath))
            {
                using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(stream);
                }
            }

        }
    }
}
