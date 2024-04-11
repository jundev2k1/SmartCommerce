// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Common;
using ErpManager.Infrastructure.Common.Enum;
using Microsoft.AspNetCore.Http;

namespace ErpManager.Infrastructure.Upload
{
    public class FileUpload : IFileUpload
    {
        public FileUpload()
        {
        }

        /// <summary>
        /// Save image
        /// </summary>
        /// <param name="file">File upload</param>
        /// <param name="enum">Type upload</param>
        /// <param name="index">Index</param>
        /// <returns>File name</returns>
        public string SaveImage(IFormFile file, UploadEnum @enum, string index = "")
        {
            var date = DateTime.Now.ToString("yyyyMMddHHmmss");
            var fileName = $"{date}_{file.FileName}";
            if (string.IsNullOrEmpty(index) == false)
            {
                fileName = $"{fileName}_{index}";
            }

            try
            {
                var filePath = this.GetFilePath(@enum);
                var imagePath = Path.Combine(filePath, fileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return fileName;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Save images
        /// </summary>
        /// <param name="files">File upload</param>
        /// <param name="enum">Type upload</param>
        /// <returns>File name collection</returns>
        public string[] SaveImages(IFormFile[] files, UploadEnum @enum)
        {
            var fileNames = new List<string>();
            var index = 0;
            foreach (var file in files)
            {
                var fileName = SaveImage(file, @enum, index.ToString());
                fileNames.Add(fileName);
                index++;
            }

            return fileNames.Where(file => string.IsNullOrEmpty(file) == false).ToArray();
        }

        /// <summary>
        /// Get file path
        /// </summary>
        /// <param name="enum">Type upload</param>
        /// <returns>File upload directory path</returns>
        public string GetFilePath(UploadEnum @enum)
        {
            return @enum switch
            {
                UploadEnum.ProductImages => Constants.FILE_UPLOAD_DIRPATH_PRODUCT_IMAGES,
                UploadEnum.UserAvatar => Constants.FILE_UPLOAD_DIRPATH_USER_AVATAR,
                UploadEnum.EmployeeAvatar => Constants.FILE_UPLOAD_DIRPATH_EMPLOYEE_AVATAR,
                _ => throw new NotImplementedException()
            };
        }
    }
}
