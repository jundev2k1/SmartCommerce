// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewModels
{
	public sealed class CreatedByBadgeViewModel
	{
		public string? CreatedName { get; set; } = string.Empty;

		public DateTime DateCreated { get; set; }

		public string ClassName { get; set; } = string.Empty;

		public bool IsPill { get; set; }
	}
}
