using Microsoft.AspNetCore.Mvc;

namespace MovieWeb.Service
{
    public interface IFileService
    {
        public IFormFile GetFile(string fileName);

        public void UploadFile(IFormFile file);

    }
}
