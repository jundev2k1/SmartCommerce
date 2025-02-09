// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewComponents
{
	public sealed class HeaderViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(HeaderViewModel viewData)
		{
			return View(viewData);
		}
	}
}
