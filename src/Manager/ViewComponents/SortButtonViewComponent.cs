// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewComponents
{
	public sealed class SortButtonViewComponent : ViewComponentBase
	{
		public IViewComponentResult Invoke(
			string sortBy = "",
			dynamic? attribute = null,
			Func<string, dynamic>? itemAttribute = null)
		{
			var onSelectItem = (string value) =>
			{
				var urlCreator = new UrlCreator(this.RequestUrl);
				urlCreator.AddParam(Constants.REQUEST_KEY_SORT_BY, sortBy);
				urlCreator.AddParam(Constants.REQUEST_KEY_SORT_DIRECTION, value);
				return urlCreator.CreateUrl();
			};
			var requestSortBy = Request.Query[Constants.REQUEST_KEY_SORT_BY].ToStringOrEmpty();
			var sortDirection = Request.Query[Constants.REQUEST_KEY_SORT_DIRECTION].ToStringOrEmpty();

			var viewModel = new SortButtonViewModel
			{
				IsSorting = sortBy == requestSortBy,
				SortBy = sortBy,
				SortDirection = sortDirection,
				Attribute = attribute,
				ItemAttribute = itemAttribute,
				OnSelectItem = onSelectItem,
			};
			return View(viewModel);
		}
	}
}
