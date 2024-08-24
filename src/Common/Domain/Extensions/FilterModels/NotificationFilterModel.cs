// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Extensions.FilterModels
{
	public sealed class NotificationFilterModel : FilterModelBase<NotificationFilterModel>
	{
		public string Keywords { get; set; } = string.Empty;

		public string BranchId { get; set; } = string.Empty;
	}
}
