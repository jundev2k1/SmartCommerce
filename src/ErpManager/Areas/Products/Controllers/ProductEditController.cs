// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.ERP.Areas.Products.Controllers;
using ErpManager.ERP.Areas.Products.ViewModels;

namespace ErpManager.ERP.Areas.Product.Controllers
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
		public IActionResult Index(string id)
		{
			var product = _serviceFacade.Products.Get(this.OperatorBranchId, id);
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
		public IActionResult Index([FromRoute] string id, ProductEditViewModel viewModel)
		{
			var pageData = viewModel.PageData;

			// Set default value for form input
			pageData.ProductId = id;
			pageData.TrimStringInput();
			SetDataForUpdate(ref pageData);

			// Set initial value for dropdown list
			viewModel.InputOptions = GetInitDropdownListItems(pageData);

			// Validate form input
			ModelState.Clear();
			var validateResult = _validatorFacade.ProductValidate(pageData);
			if (validateResult.IsValid == false)
			{
				AddErrorToModelState(validateResult);
				return View(viewModel);
			}

			// Handle update product
			var isSuccess = _serviceFacade.Products.Update(pageData);
			if (isSuccess == false) return View(viewModel);

			return RedirectToRoute(Constants.MODULE_PRODUCT_PRODUCTDETAIL_NAME, new { id = pageData.ProductId });
		}

		/// <summary>
		/// Set data for update
		/// </summary>
		/// <param name="input">Input</param>
		private void SetDataForUpdate(ref ProductModel input)
		{
			var product = _serviceFacade.Products.Get(this.OperatorBranchId, input.ProductId);
			if (product == null) return;

			var productImages = _serviceFacade.Products.UpdateNewestProductImages(product.BranchId, product.ProductId);
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
		public bool UpdateDescription([FromRoute] string id, [FromBody] string description)
		{
			var product = _serviceFacade.Products.Get(this.OperatorBranchId, id);
			if (product == null) return false;

			product.Description = description;
			return _serviceFacade.Products.UpdateDescription(product);
		}
	}
}
