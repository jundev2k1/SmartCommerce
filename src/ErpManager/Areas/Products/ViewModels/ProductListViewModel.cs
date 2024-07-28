// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Manager.Areas.Products.ViewModels
{
	public sealed class ProductListViewModel
	{
		public SearchResultModel<ProductModel> PageData { get; set; } = new SearchResultModel<ProductModel>();

		public ProductSearchDto SearchFields { get; set; } = new ProductSearchDto();

		public ProductInputOptionViewModel InputOption { get; set; } = new ProductInputOptionViewModel();

		public int PageIndex { get; set; } = 1;

		public int PageSize { get; set; } = Constants.DEFAULT_PAGE_SIZE;
	}
}
