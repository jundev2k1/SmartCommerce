// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Models
{
	public sealed class CategoryModel : ModelBase<CategoryModel>
	{
		public string BranchId { get; set; } = string.Empty;

		public string CategoryId { get; set; } = string.Empty;

		public string CategoryName { get; set; } = string.Empty;

		public string Avatar { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public string ParentCategoryId { get; set;} = string.Empty;

		public CategoryStatusEnum Status { get; set; } = CategoryStatusEnum.Active;

		public bool DelFlg { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime? DateChanged { get; set; }

		public string CreatedBy { get; set; } = string.Empty;

		public string LastChanged { get; set; } = string.Empty;
	}
}
