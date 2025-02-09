// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Domain.Models
{
	public sealed class RoleModel : ModelBase<RoleModel>
	{
		public string BranchId { get; set; } = string.Empty;

		public int RoleId { get; set; }

		public string Name { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public string PageDefault { get; set; } = string.Empty;

		public string Permission { get; set; } = string.Empty;

		public int Priority { get; set; } = 0;

		public DateTime DateCreated { get; set; }

		public DateTime? DateChanged { get; set; }

		public string CreatedBy { get; set; } = string.Empty;

		public RoleStatusEnum Status { get; set; }
	}
}
