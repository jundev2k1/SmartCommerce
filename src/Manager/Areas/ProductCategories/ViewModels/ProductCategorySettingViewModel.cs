// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.Areas.ProductCategories.ViewModels
{
	public sealed class ProductCategorySettingViewModel
    {
		public string PageData { get; set; } = string.Empty;

        public ProductCategoryFilterModel SearchFields { get; set; } = new ProductCategoryFilterModel();
    }
}
