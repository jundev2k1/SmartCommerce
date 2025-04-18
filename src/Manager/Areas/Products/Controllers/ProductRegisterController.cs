﻿// Copyright (c) 2024 - Jun Dev. All rights reserved

using SmartCommerce.Manager.Areas.Products.Controllers;
using SmartCommerce.Manager.Areas.Products.ViewModels;

namespace SmartCommerce.Manager.Areas.Product.Controllers
{
	[Area(Constants.MODULE_PRODUCT_AREA)]
	public sealed class ProductRegisterController : ProductBaseController
	{
		private readonly IValidatorFacade _validatorFacade;

		/// <summary>
		/// Constructor
		/// </summary>
		public ProductRegisterController(
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
		[Authorization(Permission.CanCreateProduct)]
		[Route(Constants.MODULE_PRODUCT_PRODUCTREGISTER_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTREGISTER_NAME)]
		public async Task<IActionResult> Index(string id = "")
		{
			var viewModel = new ProductRegisterViewModel();
			if (string.IsNullOrEmpty(id) == false)
			{
				viewModel.PageData = await _serviceFacade.Products
					.Get(this.OperatorBranchId, id) ?? new ProductModel();
				viewModel.PageData.Images = string.Empty;
			}

			viewModel.InputOptions = await GetInitDropdownListItems(viewModel.PageData);
			return View(viewModel);
		}

		[HttpPost]
		[Authorization(Permission.CanCreateProduct)]
		[Route(Constants.MODULE_PRODUCT_PRODUCTREGISTER_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTREGISTER_NAME)]
		public async Task<IActionResult> Index(ProductRegisterViewModel viewModel)
		{
			var pageData = viewModel.PageData;

			// Set default value for form input
			pageData.BranchId = this.OperatorBranchId;
			pageData.CreatedBy = this.OperatorId;
			pageData.LastChanged = this.OperatorName;
			pageData.TrimStringInput();

			// Set initial value for dropdown list
			viewModel.InputOptions = await GetInitDropdownListItems(pageData);

			// Validate form input
			var validateResult = await _validatorFacade.ProductValidate(pageData);
			if (validateResult.IsValid == false)
			{
				AddErrorToModelState(validateResult, preName: "PageData.");
				return View(viewModel);
			}

			// Convert temp images to actual images
			var fileUpload = new FileManager(
				files: Array.Empty<IFormFile>(),
				@enum: UploadEnum.ProductImage,
				sessionToken: this.SessionToken,
				fileName: pageData.ProductId);
			fileUpload.ChangeToActualImages();
			pageData.Images = string.Join(",", fileUpload.Result);

			// Handle create new product
			var isSuccess = await _serviceFacade.Products.Insert(pageData);
			if (isSuccess == false) return View(viewModel);

			return RedirectToRoute(Constants.MODULE_PRODUCT_PRODUCTLIST_NAME);
		}
	}
}
