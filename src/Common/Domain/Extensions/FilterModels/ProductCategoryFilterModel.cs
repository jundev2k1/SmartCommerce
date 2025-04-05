// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Domain.Extensions.FilterModels
{
	public sealed class ProductCategoryFilterModel : FilterModelBase<ProductCategoryFilterModel>
	{
		public string Keywords { get; set; } = string.Empty;

		public string BranchId { get; set; } = string.Empty;

		public string CategoryId { get; set; } = string.Empty;

		public string Name { get; set; } = string.Empty;

		public CategoryStatusEnum? Status { get; set; } = CategoryStatusEnum.Active;

		public string ParentId { get; set; } = string.Empty;
	}
}
