// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.ERP.Areas.Products.Controllers;

namespace ErpManager.ERP.Areas.Product.Controllers
{
	[Area(Constants.MODULE_PRODUCT_AREA)]
	public sealed class ProductDetailController : ProductBaseController
	{
		public ProductDetailController(
			IServiceFacade serviceFacade,
			IValidatorFacade validatorFacade,
			ILocalizer localizer,
			SessionManager sessionManager,
			ValueTextManager valueTextManager,
			IFileLogger logger) : base(serviceFacade, sessionManager, localizer, logger, valueTextManager)
		{
		}

		[HttpGet]
		[Authorization(Permission.CanReadDetailProduct)]
		[Route(Constants.MODULE_PRODUCT_PRODUCTDETAIL_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTDETAIL_NAME)]
		public IActionResult Index([FromRoute] string id)
		{
			var data = _serviceFacade.Products.Get(this.OperatorBranchId, id);
			if (data == null) return RedirectToErrorPage(Constants.ERRORMSG_KEY_DATA_NOT_FOUND, ErrorCodeEnum.DataNotFound);

			return View(data);
		}

		[HttpPost]
		[Authorization(Permission.CanReadDetailProduct)]
		[Route(Constants.MODULE_PRODUCT_PRODUCTDETAIL_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTDETAIL_NAME)]
		public IActionResult Index(ProductModel model)
		{
			return View();
		}

		private int GetPageIndex()
		{
			var isSuccess = int.TryParse(Request.Query[Constants.PARAM_KEY_PAGE_INDEX].ToStringOrEmpty(), out var page);
			return isSuccess ? page : 1;
		}
	}
}
