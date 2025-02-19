// Copyright (c) 2025 - Jun Dev. All rights reserved

using SmartCommerce.Manager.ViewModels;

namespace SmartCommerce.Manager.ViewComponents
{
	public sealed class DynamicListViewComponent : ViewComponentBase
	{
		public DynamicListViewComponent(
			ILocalizer localizer,
			IServiceFacade serviceFacade,
			ValueTextManager valueTextManager,
			SessionManager sessionManager)
			: base(localizer, serviceFacade, valueTextManager, sessionManager)
		{
		}

		public IViewComponentResult Invoke(DynamicListViewModel viewModel)
		{
			return View(viewModel);
		}
	}
}
