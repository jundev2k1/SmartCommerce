// Copyright (c) 2024 - Jun Dev. All rights reserved

using SmartCommerce.Domain.Extensions.FilterModels;

namespace SmartCommerce.Manager.Areas.Products.ViewModels
{
    public sealed class ProductListViewModel
	{
		public SearchResultModel<ProductModel> PageData { get; set; } = new SearchResultModel<ProductModel>();

		public ProductFilterModel SearchFields { get; set; } = new ProductFilterModel();

		public ProductInputOptionViewModel InputOption { get; set; } = new ProductInputOptionViewModel();
	}
}
