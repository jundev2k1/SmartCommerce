// Copyright (c) 2024 - Jun Dev. All rights reserved

using Microsoft.AspNetCore.Mvc;

namespace ErpManager.Web.ViewComponents
{
    public class SearchInputViewComponent : ViewComponent
    {
        /// <summary>
        /// Search input view component
        /// </summary>
        /// <param name="name">Name of input</param>
        /// <param name="type">Type of input (text, number, password,...)</param>
        /// <param name="className">Class name (for css extension)</param>
        /// <param name="isAsync">Is search async</param>
        /// <returns>Search input component</returns>
        public IViewComponentResult Invoke(string name, bool isAsync = true, string type = "text", string className = "")
        {
            ViewBag.Props = new { name, type, className, isAsync };
            return View();
        }
    }
}
