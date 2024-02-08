// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.ERP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ErpManager.ERP.ViewComponents
{
    public class BreadcrumbViewComponent : ViewComponent
    {
        /// <summary>
        /// Breadcrumb view component
        /// </summary>
        /// <param name="breadcrumbs">Breadcrumb content list</param>
        /// <returns>Breadcrumb component</returns>
        public IViewComponentResult Invoke(Breadcrumb[] breadcrumbs)
        {
            return View(breadcrumbs);
        }
    }
}
