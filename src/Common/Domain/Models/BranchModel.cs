// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Domain.Models
{
	public sealed class BranchModel : ModelBase<BranchModel>
	{
		public string BranchId { get; set; } = string.Empty;

		public string Name { get; set; } = string.Empty;

		public BranchStatusEnum Status { get; set; }

		public string Avatar { get; set; } = string.Empty;

		public DateTime? DateCreated { get; set; }

		public DateTime? LastChanged { get; set; }
	}
}
