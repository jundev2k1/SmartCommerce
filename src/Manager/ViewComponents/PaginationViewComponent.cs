// Copyright (c) 2024 - Jun Dev. All rights reserved

using Microsoft.AspNetCore.Mvc.Routing;
using SmartCommerce.Common.Helpers;

namespace SmartCommerce.Manager.ViewComponents
{
	public sealed class PaginationViewComponent : ViewComponentBase
	{
		public PaginationViewComponent(
			ILocalizer localizer,
			IServiceFacade serviceFacade,
			ValueTextManager valueTextManager,
			SessionManager sessionManager)
			: base(localizer, serviceFacade, valueTextManager, sessionManager)
		{
		}

		public IViewComponentResult Invoke(
			int itemCount,
			int totalCount,
			Func<int, string>? createUrl = null)
		{
			// Get request parameters
			var requestParams = Request.Query
				.ToDictionary(param => param.Key, param => param.Value.ToStringOrEmpty());

			// Set default create URL
			if (createUrl == null)
			{
				createUrl = (pageNo) =>
				{
					var currentUrl = $"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}";
					var urlCreator = new UrlCreator(currentUrl);
					urlCreator.AddParam(Constants.REQUEST_KEY_PAGE_NO, pageNo.ToString());
					return urlCreator.CreateUrl();
				};
			}

			// Set data to view model
			var data = new PaginationComponentViewModel()
			{
				ItemCount = itemCount,
				TotalHitCount = totalCount,
				RequestParameters = requestParams,
				CreatePaginationUrl = createUrl,
			};

			return View(data);
		}
	}
}
