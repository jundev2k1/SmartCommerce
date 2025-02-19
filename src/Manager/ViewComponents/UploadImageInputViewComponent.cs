// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewComponents
{
	public sealed class UploadImageInputViewComponent : ViewComponentBase
	{
		public UploadImageInputViewComponent(
			ILocalizer localizer,
			IServiceFacade serviceFacade,
			ValueTextManager valueTextManager,
			SessionManager sessionManager)
			: base(localizer, serviceFacade, valueTextManager, sessionManager)
		{
		}

		/// <summary>
		/// Upload image input view component
		/// </summary>
		/// <param name="input">Upload image input</param>
		/// <returns>Upload image input component</returns>
		public IViewComponentResult Invoke(UploadImageInputViewModel input)
		{
			return View(input);
		}
	}
}
