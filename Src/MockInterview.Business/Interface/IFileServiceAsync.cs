using Microsoft.AspNetCore.Http;

namespace MockInterview.Business.Interface
{
    public interface IFileServiceAsync
    {
        Task<string> UploadFileAsync(IFormFile file);
        string SetFile(string fileName);
    }
}
