// Copyright (c) 2024 - Jun Dev. All rights reserved

using Microsoft.AspNetCore.Mvc;

namespace ErpManager.ERP.ViewComponents
{
    public class SearchInputViewComponent : ViewComponent
    {
        /// <summary>
        /// Search input view component
        /// </summary>
        /// <param name="name">Name of input</param>
        /// <param name="value">Value of input</param>
        /// <param name="placeHolderText">Placeholder of input</param>
        /// <param name="type">Type of input (text, number, password,...)</param>
        /// <param name="className">Class name (for css extension)</param>
        /// <returns>Search input component</returns>
        public IViewComponentResult Invoke(string name, string value, string placeHolderText = "", string type = "text", string className = "")
        {
            ViewBag.Props = new { name, value, placeHolderText, type, className };
            return View();
        }
    }
}
