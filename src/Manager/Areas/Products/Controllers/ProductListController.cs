﻿// Copyright (c) 2024 - Jun Dev. All rights reserved

using SmartCommerce.Manager.Areas.Products.Controllers;
using SmartCommerce.Manager.Areas.Products.ViewModels;

namespace SmartCommerce.Manager.Areas.Product.Controllers
{
	[Area(Constants.MODULE_PRODUCT_AREA)]
	public sealed class ProductListController : ProductBaseController
	{
		public ProductListController(
			IServiceFacade serviceFacade,
			IValidatorFacade validatorFacade,
			ILocalizer localizer,
			SessionManager sessionManager,
			ValueTextManager valueTextManager,
			IFileLogger logger) : base(serviceFacade, sessionManager, localizer, logger, valueTextManager)
		{
		}

		[HttpGet]
		[Authorization(Permission.CanReadListProduct)]
		[Route(Constants.MODULE_PRODUCT_PRODUCTLIST_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTLIST_NAME)]
		public async Task<IActionResult> Index(int page = 1)
		{
			var condition = new ProductFilterModel { BranchId = this.OperatorBranchId };
			var productList = await _serviceFacade.Products.GetByCriteriaAsync(
				condition,
				page,
				Constants.DEFAULT_PAGE_SIZE);
			var data = new ProductListViewModel
			{
				PageData = productList,
				PageIndex = page,
				InputOption = GetInitDropdownListItems(new ProductModel()),
			};
			return View(data);
		}

		[HttpPost]
		[Authorization(Permission.CanReadListProduct)]
		[Route(Constants.MODULE_PRODUCT_PRODUCTLIST_PATH)]
		public async Task<IActionResult> Index(ProductListViewModel viewModel)
		{
			// Set default search data
			var searchParams = viewModel.SearchFields;
			searchParams.BranchId = this.OperatorBranchId;

			// Set initial value for dropdown list
			viewModel.InputOption = GetInitDropdownListItems(viewModel.SearchFields.MapSearchToModel());

			// Check page index out of range data collection
			if (viewModel.PageData.TotalPage < viewModel.PageIndex)
				viewModel.PageIndex = 1;

			viewModel.PageData = await _serviceFacade.Products.GetByCriteriaAsync(
				searchParams,
				viewModel.PageIndex,
				viewModel.PageSize);
			return View(viewModel);
		}
	}
}
