// Copyright (c) 2024 - Jun Dev. All rights reserved

using Microsoft.AspNetCore.Mvc;

namespace ErpManager.ERP.ViewComponents
{
    public class SearchInputViewComponent : ViewComponent
    {
        /// <summary>
        /// Search input view component
        /// </summary>
        /// <param name="input">Search input model</param>
        /// <returns>Search input component</returns>
        public IViewComponentResult Invoke(SearchInputViewModel input)
        {
            return View(input);
        }
    }
}
