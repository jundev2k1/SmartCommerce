// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Domain.Extensions.FilterModels
{
	public sealed class ProductFilterModel : FilterModelBase<ProductFilterModel>
	{
		public string Keywords { get; set; } = string.Empty;

		public string BranchId { get; set; } = string.Empty;

		public string ProductId { get; set; } = string.Empty;

		public string ProductName { get; set; } = string.Empty;

		public string Address1 { get; set; } = string.Empty;

		public string Address2 { get; set; } = string.Empty;

		public string Address3 { get; set; } = string.Empty;

		public string Address4 { get; set; } = string.Empty;

		public DisplayPriceEnum? DisplayPrice { get; set; } = DisplayPriceEnum.Price1;

		public decimal? MinPrice1 { get; set; }

		public decimal? MaxPrice1 { get; set; }

		public decimal? MinPrice2 { get; set; }

		public decimal? MaxPrice2 { get; set; }

		public decimal? MinPrice3 { get; set; }

		public decimal? MaxPrice3 { get; set; }

		public decimal? MinSize1 { get; set; }

		public decimal? MaxSize1 { get; set; }

		public decimal? MinSize2 { get; set; }

		public decimal? MaxSize2 { get; set; }

		public decimal? MinSize3 { get; set; }

		public decimal? MaxSize3 { get; set; }

		public string TakeOverId { get; set; } = string.Empty;

		public ProductStatusEnum? Status { get; set; } = ProductStatusEnum.Normal;

		public string categoryIds { get; set; } = string.Empty;
	}
}
