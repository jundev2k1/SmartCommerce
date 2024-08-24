// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Extensions.FilterModels
{
	public sealed class CategoryFilterModel : FilterModelBase<CategoryFilterModel>
	{
		public string Keywords { get; set; } = string.Empty;

		public string BranchId { get; set; } = string.Empty;

		public string CategoryId { get; set; } = string.Empty;

		public string CategoryName { get; set; } = string.Empty;

		public CategoryStatusEnum? Status { get; set; } = CategoryStatusEnum.Active;

		public string ParentCategoryId { get; set; } = string.Empty;
	}
}
