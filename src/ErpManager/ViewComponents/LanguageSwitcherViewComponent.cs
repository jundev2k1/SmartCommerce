// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.ViewComponents
{
	public sealed class LanguageSwitcherViewComponent : ViewComponent
	{
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
