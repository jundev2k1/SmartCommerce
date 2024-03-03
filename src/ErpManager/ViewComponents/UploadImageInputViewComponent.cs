// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.ViewComponents
{
    public class UploadImageInputViewComponent : ViewComponent
    {
        /// <summary>
        /// Upload image input view component
        /// </summary>
        /// <param name="input">Upload image input</param>
        /// <returns>Search input component</returns>
        public IViewComponentResult Invoke(UploadImageInputViewModel input)
        {
            return View(input);
        }
    }
}
