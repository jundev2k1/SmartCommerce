// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Extensions.FilterModels
{
	public sealed class RoleFilterModel : FilterModelBase<RoleFilterModel>
	{
		public string Keywords { get; set; } = string.Empty;

		public string BranchId { get; set; } = string.Empty;

		public int RoleId { get; set; }

		public string Name { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public string Permission { get; set; } = string.Empty;

		public int? Priority { get; set; } = 0;

		public RoleStatusEnum Status { get; set; }
	}
}
