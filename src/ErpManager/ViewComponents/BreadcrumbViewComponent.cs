// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Web.ViewModels.Component;
using Microsoft.AspNetCore.Mvc;

namespace ErpManager.Web.ViewComponents
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
