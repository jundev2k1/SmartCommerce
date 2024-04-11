using ErpManager.Infrastructure.Common.Enum;
using Microsoft.AspNetCore.Http;

namespace ErpManager.Infrastructure.Upload
{
    public interface IFileUpload
    {
        public string SaveImage(IFormFile file, UploadEnum @enum, string index = "");

        public string[] SaveImages(IFormFile[] files, UploadEnum @enum);

        public string GetFilePath(UploadEnum @enum);
    }
}
