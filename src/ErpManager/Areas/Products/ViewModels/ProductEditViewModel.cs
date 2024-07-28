// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Manager.Areas.Products.ViewModels
{
	public sealed class ProductEditViewModel
	{
		public ProductModel PageData { get; set; } = new ProductModel();

		public ProductInputOptionViewModel InputOptions { get; set; } = new ProductInputOptionViewModel();
	}
}
