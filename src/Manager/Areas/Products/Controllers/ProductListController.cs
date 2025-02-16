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
			var condition = GetFiltersByRequest();
			var productList = await _serviceFacade.Products.GetByCriteriaAsync(
				condition,
				condition.PageNumber,
				condition.PageSize);
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

		/// <summary>
		/// Get filters by request
		/// </summary>
		/// <returns>Product filters</returns>
		private ProductFilterModel GetFiltersByRequest()
		{
			var parameter = new ProductFilterModel()
			{
				Keywords = GetRequestParam<string>(Constants.REQUEST_KEY_PRODUCT_SEARCH_WORD, string.Empty),
				BranchId = this.OperatorBranchId,
				ProductId = GetRequestParam<string>(Constants.REQUEST_KEY_PRODUCT_PRODUCT_ID, string.Empty),
				ProductName = GetRequestParam<string>(Constants.REQUEST_KEY_PRODUCT_PRODUCT_NAME, string.Empty),
				Address1 = GetRequestParam<string>(Constants.REQUEST_KEY_PRODUCT_ADDRESS1, string.Empty),
				Address2 = GetRequestParam<string>(Constants.REQUEST_KEY_PRODUCT_ADDRESS2, string.Empty),
				Address3 = GetRequestParam<string>(Constants.REQUEST_KEY_PRODUCT_ADDRESS3, string.Empty),
				Address4 = GetRequestParam<string>(Constants.REQUEST_KEY_PRODUCT_ADDRESS4, string.Empty),
				DisplayPrice = GetRequestParam<DisplayPriceEnum>(Constants.REQUEST_KEY_PRODUCT_PRICE_TYPE, DisplayPriceEnum.Price1),
				MinPrice1 = GetRequestParam<decimal?>(Constants.REQUEST_KEY_PRODUCT_MIN_PRICE1, null),
				MaxPrice1 = GetRequestParam<decimal?>(Constants.REQUEST_KEY_PRODUCT_MAX_PRICE1, null),
				MinPrice2 = GetRequestParam<decimal?>(Constants.REQUEST_KEY_PRODUCT_MIN_PRICE2, null),
				MaxPrice2 = GetRequestParam<decimal?>(Constants.REQUEST_KEY_PRODUCT_MAX_PRICE2, null),
				MinPrice3 = GetRequestParam<decimal?>(Constants.REQUEST_KEY_PRODUCT_MIN_PRICE3, null),
				MaxPrice3 = GetRequestParam<decimal?>(Constants.REQUEST_KEY_PRODUCT_MAX_PRICE3, null),
				MinSize1 = GetRequestParam<decimal?>(Constants.REQUEST_KEY_PRODUCT_MIN_SIZE1, null),
				MaxSize1 = GetRequestParam<decimal?>(Constants.REQUEST_KEY_PRODUCT_MAX_SIZE1, null),
				MinSize2 = GetRequestParam<decimal?>(Constants.REQUEST_KEY_PRODUCT_MIN_SIZE2, null),
				MaxSize2 = GetRequestParam<decimal?>(Constants.REQUEST_KEY_PRODUCT_MAX_SIZE2, null),
				MinSize3 = GetRequestParam<decimal?>(Constants.REQUEST_KEY_PRODUCT_MIN_SIZE3, null),
				MaxSize3 = GetRequestParam<decimal?>(Constants.REQUEST_KEY_PRODUCT_MAX_SIZE3, null),
				TakeOverId = GetRequestParam<string>(Constants.REQUEST_KEY_PRODUCT_TAKE_OVER_ID, string.Empty),
				Status = GetRequestParam<ProductStatusEnum>(Constants.REQUEST_KEY_PRODUCT_STATUS, ProductStatusEnum.Normal),
				categoryId = GetRequestParam<string>(Constants.REQUEST_KEY_PRODUCT_CATEGORY_ID, string.Empty),
				PageNumber = GetRequestParam<int>(Constants.REQUEST_KEY_PAGE_NO, 1),
				PageSize = GetRequestParam<int>(Constants.REQUEST_KEY_PAGE_SIZE, Constants.DEFAULT_PAGE_SIZE),
			};
			return parameter;
		}
	}
}
