// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Domain.Extensions.FilterModels
{
	public sealed class RoleFilterModel : FilterModelBase<RoleFilterModel>
	{
		public string Keywords { get; set; } = string.Empty;

		public string BranchId { get; set; } = string.Empty;

		public RoleStatusEnum Status { get; set; }
	}
}
