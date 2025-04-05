// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace SmartCommerce.Domain.Models
{
	public sealed class ProductCategoryModel
	{
		public string BranchId { get; set; } = string.Empty;

		public string CategoryId { get; set; } = string.Empty;

		public string ParentId { get; set; } = string.Empty;

		public string Name { get; set; } = string.Empty;

		public string Avatar { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

        public int Priority { get; set; }

        public bool ValidFlg { get; set; }

		public bool DelFlg { get; set; }

		public DateTime? DateCreated { get; set; }

		public DateTime? DateChanged { get; set; }

		public string CreatedBy { get; set; } = string.Empty;

		public string LastChanged { get; set; } = string.Empty;
	}
}
