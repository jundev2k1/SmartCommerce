﻿// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewComponents
{
	public sealed class SiteMetaViewComponent : ViewComponentBase
	{
		public SiteMetaViewComponent(
			ILocalizer localizer,
			IServiceFacade serviceFacade,
			ValueTextManager valueTextManager,
			SessionManager sessionManager)
			: base(localizer, serviceFacade, valueTextManager, sessionManager)
		{
		}

		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
