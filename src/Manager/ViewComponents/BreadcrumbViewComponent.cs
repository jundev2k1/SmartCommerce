// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewComponents
{
	public sealed class BreadcrumbViewComponent : ViewComponentBase
	{
		public BreadcrumbViewComponent(
			ILocalizer localizer,
			IServiceFacade serviceFacade,
			ValueTextManager valueTextManager,
			SessionManager sessionManager)
			: base(localizer, serviceFacade, valueTextManager, sessionManager)
		{
		}

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
