// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Infrastructure.Common.Enum;
using ErpManager.Infrastructure.Upload;

namespace ErpManager.ERP.ViewComponents
{
    public sealed class UploadImageInputViewComponent : ViewComponent
    {
        private readonly IFileUpload _fileUpload;
        public UploadImageInputViewComponent(IFileUpload fileUpload)
        {
            _fileUpload = fileUpload;
        }

        /// <summary>
        /// Upload image input view component
        /// </summary>
        /// <param name="input">Upload image input</param>
        /// <returns>Upload image input component</returns>
        public IViewComponentResult Invoke(UploadImageInputViewModel input)
        {
            ViewBag.ProductUploadDirPath = _fileUpload.GetFilePath(UploadEnum.ProductImages);
            return View(input);
        }
    }
}
