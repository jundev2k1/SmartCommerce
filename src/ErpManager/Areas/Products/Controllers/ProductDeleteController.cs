// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Manager.Areas.Products.Controllers;

namespace ErpManager.Manager.Areas.Product.Controllers
{
	[Area(Constants.MODULE_PRODUCT_AREA)]
	public sealed class ProductDeleteController : ProductBaseController
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public ProductDeleteController(
			IServiceFacade serviceFacade,
			IValidatorFacade validatorFacade,
			ILocalizer localizer,
			SessionManager sessionManager,
			ValueTextManager valueTextManager,
			IFileLogger logger) : base(serviceFacade, sessionManager, localizer, logger, valueTextManager)
		{
		}

		[HttpGet]
		[Authorization(Permission.CanDeleteProduct)]
		[Route(Constants.MODULE_PRODUCT_PRODUCTDELETE_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTDELETE_NAME)]
		public IActionResult Index(string id)
		{
			var product = _serviceFacade.Products.Get(this.OperatorBranchId, id);
			if (product == null) return RedirectToRoute(Constants.MODULE_ERROR_ERROR_NAME);

			var isSuccess = _serviceFacade.Products.Delete(this.OperatorBranchId, product.ProductId);
			if (!isSuccess) RedirectToRoute(Constants.MODULE_ERROR_ERROR_NAME);

			return RedirectToRoute(Constants.MODULE_PRODUCT_PRODUCTLIST_NAME);
		}
	}
}
