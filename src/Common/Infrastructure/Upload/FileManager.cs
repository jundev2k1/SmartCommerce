// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Common;
using ErpManager.Infrastructure.Common.Enum;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace ErpManager.Infrastructure.Upload
{
    public class FileManager
    {
        private readonly IFormFile[] _files;
        private readonly string _fileNameFormat;
        private readonly string _sessionToken;

        // Local constant
        private const string CONST_TEMP_FILE_NAME = "temp_file_name";
        private const string CONST_ROOT_DIR = "wwwroot";

        public FileManager(
            IFormFile[] files,
            UploadEnum @enum,
            string fileName = CONST_TEMP_FILE_NAME,
            string sessionToken = "")
        {
            this.HasFileName = !string.IsNullOrEmpty(fileName) && (fileName != CONST_TEMP_FILE_NAME);
            this.FileName = this.HasFileName ? fileName : string.Empty;
            _files = files;
            _fileNameFormat = this.HasFileName ? $"{fileName}_{{0}}" : fileName;
            _sessionToken = sessionToken;

            Initialize(@enum);
        }
        public FileManager(
            IFormFile file,
            UploadEnum @enum,
            string fileName = CONST_TEMP_FILE_NAME,
            string sessionToken = "")
        {
            this.HasFileName = !string.IsNullOrEmpty(fileName) && (fileName != CONST_TEMP_FILE_NAME);
            _files = new IFormFile[] { file };
            _fileNameFormat = this.HasFileName
                ? fileName
                : file.Name;
            this.FileName = _fileNameFormat;
            _sessionToken = sessionToken;

            Initialize(@enum);
        }

        /// <summary>
        /// Initialize
        /// </summary>
        private void Initialize(UploadEnum @enum)
        {
            try
            {
                this.HandleFilePath = GetActualFilePath(@enum);
                CreateIfNotExistDirectory(this.HandleFilePath);

                this.TempFilePath = GetTempFilePath(@enum);
                CreateIfNotExistDirectory(this.TempFilePath);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Save image
        /// </summary>
        /// <param name="targetFile">Target file upload</param>
        /// <param name="index">Index</param>
        /// <returns>File name</returns>
        public string UploadImage(IFormFile targetFile, string index = "")
        {
            if (this.HasFileName && string.IsNullOrEmpty(index))
            {
                index = GetNextIndex().ToString();
            }
            // Get file name
            var extensionName = Path.GetExtension(targetFile.FileName);
            var fileName = (this.HasFileName)
                ? $"{string.Format(_fileNameFormat, index)}{extensionName}"
                : targetFile.FileName;

            try
            {
                var dirPath = this.HasFileName
                    ? this.HandleFilePath
                    : this.TempFilePath;
                var imagePath = Path.Combine(dirPath, fileName);
                if (File.Exists(imagePath))
                {
                    // Check and increase index if duplicate file name
                    var indexIncrease = GetHandleFiles()
                        .Where(path => IsDuplicateFileName(path, fileName))
                        .Select(path => GetDuplicateFileIndex(Path.GetFileNameWithoutExtension(path)))
                        .Max() + 1;
                    var fileExtension = Path.GetExtension(fileName);
                    var fileNameWithOutExtension = Path.GetFileNameWithoutExtension(fileName);
                    var newFileName = $"{fileNameWithOutExtension} ({indexIncrease}){fileExtension}";
                    imagePath = Path.Combine(dirPath, newFileName);
                }

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    targetFile.CopyTo(stream);
                }
                return imagePath.Replace(CONST_ROOT_DIR, string.Empty).ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Execute upload images
        /// </summary>
        /// <returns>File name collection</returns>
        public void ExecuteUploadImages()
        {
            var fileNames = new List<string>();
            var index = GetNextIndex();
            foreach (var file in _files)
            {
                var fileName = UploadImage(file, index.ToString());
                if (!string.IsNullOrEmpty(fileName))
                    fileNames.Add(fileName);

                index++;
            }

            this.Result = fileNames.ToArray();
        }

        /// <summary>
        /// Change to actual images
        /// </summary>
        public void ChangeToActualImages()
        {
            var result = new List<string>();
            try
            {
                var index = 0;
                var files = Directory.GetFiles(this.TempFilePath);
                foreach (var file in files)
                {
                    var extension = Path.GetExtension(file);
                    var fileName = this.HasFileName
                        ? string.Format($"{_fileNameFormat}{extension}", index)
                        : Path.GetFileName(file);
                    var targetPath = Path.Combine(this.HandleFilePath, fileName);

                    // Delete if exist file name
                    if (File.Exists(targetPath)) File.Delete(targetPath);

                    File.Copy(file, targetPath);

                    result.Add(targetPath.Replace(CONST_ROOT_DIR, string.Empty).ToString());
                    index++;
                }

                DeleteNotExistImages(this.HandleFilePath, result.ToArray());
                DeleteTempImages();
                this.Result = result.ToArray();
            }
            catch (Exception ex)
            {
                if (this.HasFileName)
                {
                    // Temporary idea
                    var files = Directory.GetFiles(this.HandleFilePath);
                    var headImage = _fileNameFormat.Replace("{0}", string.Empty);
                    this.Result = files.Where(path => Path.GetFileName(path).StartsWith(headImage)).ToArray();
                }

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Is duplicate file name
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="fileName">File name</param>
        /// <returns>Is duplicate?</returns>
        private bool IsDuplicateFileName(string path, string fileName)
        {
            var targetFileName = Path.GetFileName(path);
            var targetFileNameWithOutExtension = Path.GetFileNameWithoutExtension(path);

            // Remove index pattern for check. Ex: pro1 (1), pro1 (2),...
            var separateIndex = targetFileName.LastIndexOf(' ');
            var fileNameForRegex = (separateIndex > 0)
                ? targetFileNameWithOutExtension.Substring(0, separateIndex)
                : targetFileNameWithOutExtension;
            // Custom regex for check duplicate file
            var patternRegex = $"^{fileNameForRegex} {Constants.REGEX_FOR_CHECK_FILENAME_DUPLICATE}";

            return (targetFileName.Equals(fileName)
                || (targetFileName.StartsWith(Path.GetFileNameWithoutExtension(fileName))
                    && Regex.IsMatch(targetFileNameWithOutExtension, patternRegex)));
        }

        /// <summary>
        /// Get duplicate file index
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns>Duplicate file index</returns>
        private int GetDuplicateFileIndex(string fileName)
        {
            var indexPattern = fileName.Split(' ').Last();
            var regex = new Regex(Constants.REGEX_FOR_CHECK_FILENAME_DUPLICATE);
            var match = regex.Match(indexPattern);

            var index = string.Empty;
            if (match.Success)
                index = match.Groups[1].Value;

            int.TryParse(index, out var result);
            return result;
        }

        /// <summary>
        /// Delete not exist images
        /// </summary>
        /// <param name="targetPath">Target path</param>
        /// <param name="expectImages">Expect images</param>
        private void DeleteNotExistImages(string targetPath, string[] expectImages)
        {
            if (!this.HasFileName || !Directory.Exists(targetPath)) return;

            var headName = _fileNameFormat.Replace("{0}", string.Empty);
            var files = Directory.GetFiles(targetPath)
                .Where(path => Path.GetFileName(path).StartsWith(headName));
            var expectImageNames = expectImages.Select(f => Path.GetFileName(f));
            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);
                var isExistFile = expectImageNames.Contains(fileName);
                if (isExistFile) continue;

                File.Delete(file);
            }
        }

        /// <summary>
        /// Create if not exist directory
        /// </summary>
        /// <param name="path">Path</param>
        private void CreateIfNotExistDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        /// <summary>
        /// Delete not use temporary images
        /// </summary>
        /// <param name="expectImages">Expect images</param>
        public void DeleteNotUseImages(string[] expectImages, bool isTempDir = false)
        {
            var expectImageNames = expectImages
                .Select(f => Path.GetFileName(f))
                .ToArray();
            var filePath = isTempDir ? this.TempFilePath : this.HandleFilePath;
            var files = Directory.GetFiles(filePath).ToArray();
            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);
                var isExistFile = expectImageNames.Contains(fileName);
                if (isExistFile) continue;

                File.Delete(file);
            }
        }

        /// <summary>
        /// Delete temporary images
        /// </summary>
        public void DeleteTempImages()
        {
            if (Directory.Exists(this.TempFilePath))
            {
                Directory.Delete(this.TempFilePath, true);
            }
            Directory.CreateDirectory(this.TempFilePath);
        }

        /// <summary>
        /// Get file path
        /// </summary>
        /// <param name="enum">Type upload</param>
        /// <returns>File upload directory path</returns>
        public string GetTempFilePath(UploadEnum @enum)
        {
            return @enum switch
            {
                UploadEnum.ProductImage => Path.Combine(Constants.ERP_FILE_UPLOAD_DIRPATH_TEMP_PRODUCT_IMAGES, _sessionToken),
                UploadEnum.UserAvatar => Path.Combine(Constants.ERP_FILE_UPLOAD_DIRPATH_TEMP_USER_AVATAR, _sessionToken),
                UploadEnum.EmployeeAvatar => Path.Combine(Constants.ERP_FILE_UPLOAD_DIRPATH_TEMP_EMPLOYEE_AVATAR, _sessionToken),
                _ => throw new NotImplementedException()
            };
        }

        /// <summary>
        /// Get actual file path
        /// </summary>
        /// <param name="type">Upload type</param>
        /// <returns>Actual file path</returns>
        public string GetActualFilePath(UploadEnum type)
        {
            return type switch
            {
                UploadEnum.ProductImage => Constants.ERP_FILE_UPLOAD_DIRPATH_PRODUCT_IMAGES,
                UploadEnum.UserAvatar => Constants.ERP_FILE_UPLOAD_DIRPATH_USER_AVATAR,
                UploadEnum.EmployeeAvatar => Constants.ERP_FILE_UPLOAD_DIRPATH_EMPLOYEE_AVATAR,
                _ => string.Empty
            };
        }

        /// <summary>
        /// Get all actual file name
        /// </summary>
        /// <returns>All actual file name</returns>
        public string[] GetAllActualFileName()
        {
            var result = Directory.GetFiles(this.HandleFilePath)
                .Where(path => string.IsNullOrEmpty(this.FileName)
                    || path.Contains(this.FileName))
                .Select(path => path.Replace("wwwroot", string.Empty).Replace("\\", "/"))
                .ToArray();
            return result;
        }

        /// <summary>
        /// Get handle file
        /// </summary>
        /// <returns>All handle file</returns>
        private string[] GetHandleFiles()
        {
            var result = (this.HasFileName)
                ? Directory.GetFiles(this.HandleFilePath)
                    .Where(path => path.Contains(this.FileName))
                    .ToArray()
                : Directory.GetFiles(this.TempFilePath);

            return result;
        }

        /// <summary>
        /// Get next index
        /// </summary>
        /// <returns>Next index</returns>
        private int GetNextIndex()
        {
            if (!this.HasFileName) return 0;

            var files = Directory.GetFiles(this.HandleFilePath);
            var filesIndex = files
                .Select(file => Path.GetFileName(file))
                .Where(file => file.StartsWith(this.FileName))
                .Select(file =>
                {
                    int.TryParse(file.Replace($"{this.FileName}_", string.Empty), out var index);
                    return index;
                });
            return filesIndex.Any() ? filesIndex.Max() + 1 : 1;
        }

        /// <summary>Result change every actual images change</summary>
        public string[] Result { get; private set; } = Array.Empty<string>();
        /// <summary>Handle file path</summary>
        public string HandleFilePath { get; private set; } = string.Empty;
        /// <summary>Temporary file path</summary>
        public string TempFilePath { get; private set; } = string.Empty;
        /// <summary>Has file name</summary>
        public bool HasFileName { get; private set; }
        /// <summary>Is handle temporary</summary>
        public bool IsHandleTemporary { get; private set; }
        /// <summary>File name with out format</summary>
        public string FileName { get; private set; }
    }
}
