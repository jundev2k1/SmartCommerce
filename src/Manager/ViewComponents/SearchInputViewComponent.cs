// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewComponents
{
	public sealed class SearchInputViewComponent : ViewComponentBase
	{
		public SearchInputViewComponent(
			ILocalizer localizer,
			IServiceFacade serviceFacade,
			ValueTextManager valueTextManager,
			SessionManager sessionManager)
			: base(localizer, serviceFacade, valueTextManager, sessionManager)
		{
		}

		/// <summary>
		/// Search input view component
		/// </summary>
		/// <param name="input">Search input model</param>
		/// <returns>Search input component</returns>
		public IViewComponentResult Invoke(SearchInputViewModel input)
		{
			return View(input);
		}
	}
}
