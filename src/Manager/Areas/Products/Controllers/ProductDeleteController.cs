// Copyright (c) 2024 - Jun Dev. All rights reserved

using SmartCommerce.Manager.Areas.Products.Controllers;

namespace SmartCommerce.Manager.Areas.Product.Controllers
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
		public async Task<IActionResult> Index(string id)
		{
			var product = await _serviceFacade.Products.Get(this.OperatorBranchId, id);
			if (product == null) return RedirectToRoute(Constants.MODULE_ERROR_ERROR_NAME);

			var isSuccess = await _serviceFacade.Products.Delete(this.OperatorBranchId, product.ProductId);
			if (!isSuccess) RedirectToErrorPage(string.Empty);

			return RedirectToRoute(Constants.MODULE_PRODUCT_PRODUCTLIST_NAME);
		}
	}
}
