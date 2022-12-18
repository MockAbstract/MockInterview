using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MockInterview.Business.Interface;
using System.IO;

namespace MockInterview.Business.Services
{
    public class FileServiceAsync : IFileServiceAsync
    {
        public FileServiceAsync(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }
        private static string PathFile = "Images";
        private readonly IWebHostEnvironment environment;

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            string path = "";
            try
            {
                if (file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(environment.WebRootPath, PathFile));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    var extension = Path.GetExtension(file.FileName);
                    var fileName = Guid.NewGuid().ToString() + extension;
                    using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return fileName;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string SetFile(string fileName)
        {
            string path = Path.GetFullPath(Path.Combine(environment.WebRootPath, PathFile));

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return Path.Combine(path, fileName);
        }
    }
}
