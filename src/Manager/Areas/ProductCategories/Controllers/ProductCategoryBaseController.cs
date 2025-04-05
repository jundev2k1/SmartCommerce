// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.Areas.ProductCategories.Controllers
{
	public class ProductCategoryBaseController : BaseController
	{
		protected readonly ValueTextManager _valueTextManager;

		public ProductCategoryBaseController(
			IServiceFacade serviceFacade,
			SessionManager sessionManager,
			ILocalizer localizer,
			IFileLogger logger,
			ValueTextManager valueTextManager) : base(serviceFacade, sessionManager, localizer, logger)
		{
			_valueTextManager = valueTextManager;
		}
	}
}
