// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewComponents
{
	public sealed class CarouselViewComponent : ViewComponentBase
	{
		public CarouselViewComponent(
			ILocalizer localizer,
			IServiceFacade serviceFacade,
			ValueTextManager valueTextManager,
			SessionManager sessionManager)
			: base(localizer, serviceFacade, valueTextManager, sessionManager)
		{
		}

		public IViewComponentResult Invoke(string images, string idTarget)
		{
			if (string.IsNullOrEmpty(images))
			{
				images = Constants.SCM_FILE_PATH_PUBLIC_NO_IMAGE;
			}

			var imageList = images.Split(',', StringSplitOptions.RemoveEmptyEntries);

			return View((imageList, idTarget));
		}
	}
}
