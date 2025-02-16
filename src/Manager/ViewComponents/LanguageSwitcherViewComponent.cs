// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewComponents
{
	public sealed class LanguageSwitcherViewComponent : ViewComponentBase
	{
		public LanguageSwitcherViewComponent(
			ILocalizer localizer,
			IServiceFacade serviceFacade,
			ValueTextManager valueTextManager,
			SessionManager sessionManager)
			: base(localizer, serviceFacade, valueTextManager, sessionManager)
		{
		}

		public IViewComponentResult Invoke()
		{
			var model = new LanguageSwitcherViewModel
			{
				CurrentCulture = System.Threading.Thread.CurrentThread.CurrentCulture.Name,
				AvailableCultures = new[]
				{
					new CultureViewModel { Culture = "en-US", DisplayName = "English" },
					new CultureViewModel { Culture = "vi-VN", DisplayName = "Tiếng Việt" }
				}
			};
			return View(model);
		}
	}
}
