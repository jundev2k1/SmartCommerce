// Copyright (c) 2024 - Jun Dev. All rights reserved

using SmartCommerce.Manager.Areas.Products.Controllers;
using SmartCommerce.Manager.Areas.Products.ViewModels;

namespace SmartCommerce.Manager.Areas.Product.Controllers
{
	[Area(Constants.MODULE_PRODUCT_AREA)]
	public sealed class ProductEditController : ProductBaseController
	{
		private readonly IValidatorFacade _validatorFacade;

		/// <summary>
		/// Constructor
		/// </summary>
		public ProductEditController(
			IServiceFacade serviceFacade,
			IValidatorFacade validatorFacade,
			ILocalizer localizer,
			SessionManager sessionManager,
			ValueTextManager valueTextManager,
			IFileLogger logger) : base(serviceFacade, sessionManager, localizer, logger, valueTextManager)
		{
			_validatorFacade = validatorFacade;
		}

		[HttpGet]
		[Authorization(Permission.CanEditProduct)]
		[Route(Constants.MODULE_PRODUCT_PRODUCTEDIT_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTEDIT_NAME)]
		public async Task<IActionResult> Index(string id)
		{
			var product = await _serviceFacade.Products.Get(this.OperatorBranchId, id);
			if (product == null)
			{
				return RedirectToErrorPage(
					_localizer.Messages["ErrorMessage_DataNotFound"].Value,
					ErrorCodeEnum.DataNotFound);
			}

			var viewModel = new ProductEditViewModel
			{
				PageData = product,
				InputOptions = GetInitDropdownListItems(new ProductModel()),
			};
			return View(viewModel);
		}

		[HttpPost]
		[Authorization(Permission.CanEditProduct)]
		[Route(Constants.MODULE_PRODUCT_PRODUCTEDIT_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTEDIT_NAME)]
		public async Task<IActionResult> Index([FromRoute] string id, ProductEditViewModel viewModel)
		{
			var pageData = viewModel.PageData;

			// Set default value for form input
			pageData.ProductId = id;
			pageData.TrimStringInput();
			await SetDataForUpdate(pageData);

			// Set initial value for dropdown list
			viewModel.InputOptions = GetInitDropdownListItems(pageData);

			// Validate form input
			var validateResult = await _validatorFacade.ProductValidate(pageData);
			if (validateResult.IsValid == false)
			{
				AddErrorToModelState(validateResult, preName: "PageData.");
				return View(viewModel);
			}

			// Handle update product
			var isSuccess = await _serviceFacade.Products.Update(pageData);
			if (isSuccess == false) return View(viewModel);

			return RedirectToRoute(Constants.MODULE_PRODUCT_PRODUCTDETAIL_NAME, new { id = pageData.ProductId });
		}

		/// <summary>
		/// Set data for update
		/// </summary>
		/// <param name="input">Input</param>
		private async Task SetDataForUpdate(ProductModel input)
		{
			var product = await _serviceFacade.Products.Get(this.OperatorBranchId, input.ProductId);
			if (product == null) return;

			var productImages = await _serviceFacade.Products
				.UpdateNewestProductImages(product.BranchId, product.ProductId);
			if (productImages == null) throw new NotExistInDBException();

			input.BranchId = this.OperatorBranchId;
			input.Images = productImages;
			input.Description = product.Description;
			input.LastChanged = this.OperatorName;
			input.DateChanged = DateTime.Now;
			input.DateCreated = product?.DateCreated;
			input.CreatedBy = product?.CreatedBy ?? this.OperatorId;
		}

		[HttpPost]
		[Authorization(Permission.CanEditProduct)]
		[Route(Constants.MODULE_PRODUCT_PRODUCTEDIT_DESCRIPTION_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTEDIT_DESCRIPTION_NAME)]
		public async Task<bool> UpdateDescription([FromBody] Hashtable data)
		{
			var id = data["id"].ToStringOrEmpty();
			var description = data["description"].ToStringOrEmpty();
			var product = await _serviceFacade.Products.Get(this.OperatorBranchId, id);
			if (product == null) return false;

			product.Description = description;
			return await _serviceFacade.Products.UpdateDescription(product);
		}
	}
}
