// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Manager.Areas.Products.Controllers;
using ErpManager.Manager.Areas.Products.ViewModels;

namespace ErpManager.Manager.Areas.Product.Controllers
{
	[Area(Constants.MODULE_PRODUCT_AREA)]
	public sealed class ProductPreviewController : ProductBaseController
	{
		public ProductPreviewController(
			IServiceFacade serviceFacade,
			SessionManager sessionManager,
			ILocalizer localizer,
			IFileLogger logger,
			ValueTextManager valueTextManager) : base(
				serviceFacade,
				sessionManager,
				localizer,
				logger,
				valueTextManager)
		{
		}

		[HttpGet]
		[AllowAnonymous]
		[Route(Constants.MODULE_PRODUCT_PRODUCTPREVIEW_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTPREVIEW_NAME)]
		public IActionResult Index([FromQuery] string branchId, string id, string token = "")
		{
			// Check token if not logged in
			if (!this.IsLogin)
			{
				var isValid = string.IsNullOrEmpty(token) == false
					&& _serviceFacade.Tokens.IsValid(branchId, TokenTypeEnum.ProductPreviewToken, token);
				if (!isValid) return RedirectToErrorPage(Constants.ERRORMSG_KEY_TOKEN_INVALID, ErrorCodeEnum.TokenInvalid);
			}

			// Check exist product
			var product = _serviceFacade.Products.Get(branchId, id);
			if (product == null) return RedirectToErrorPage(Constants.ERRORMSG_KEY_DATA_NOT_FOUND, ErrorCodeEnum.DataNotFound);

			var data = GetProductViewData(product);
			return View(data);
		}

		/// <summary>
		/// Get view data for display
		/// </summary>
		/// <param name="product">Product model</param>
		/// <returns>View model</returns>
		private ProductPreviewViewModel GetProductViewData(ProductModel product)
		{
			var user = _serviceFacade.Users.Get(this.OperatorBranchId, product.TakeOverId);
			var relatedProduct = _serviceFacade.Products
				.GetRelatedProducts(this.OperatorBranchId, product.ProductId);
			var currentPath = Path.Combine(
				this.Request.Host.Value,
				this.Request.Path);
			var data = new ProductPreviewViewModel
			{
				Product = product,
				AgentDetail = user,
				RelatedProducts = relatedProduct,
				QRCode = QRCodeUtility.GetSrcImageQRCode(currentPath),
				CanShareQRCode = HasPermission(Permission.CanSharePreviewProduct)
			};

			return data;
		}
	}
}
