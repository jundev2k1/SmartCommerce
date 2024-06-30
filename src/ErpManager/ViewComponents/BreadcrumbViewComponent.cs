// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.ViewComponents
{
	public sealed class BreadcrumbViewComponent : ViewComponent
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
