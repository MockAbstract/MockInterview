using Microsoft.AspNetCore.Http;
using System.IO;

namespace MockInterview.Business.Services
{
    public class FileServiceAsync
    {
        private static string PathFile = "Images";
        public static async Task<string> UploadFile(IFormFile file)
        {
            string path = "";
            try
            {
                if (file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, PathFile));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    var fileName = Guid.NewGuid().ToString();
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

        public static string SetFile(string fileName)
        {
            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, PathFile));

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return Path.Combine(path, fileName);
        }
    }
}
