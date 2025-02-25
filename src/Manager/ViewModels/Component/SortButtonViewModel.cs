// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewModels
{
	public sealed class SortButtonViewModel
	{
		public bool IsSorting { get; set; }

		public string SortBy { get; set; } = string.Empty;

		public string SortDirection { get; set; } = string.Empty;

		public dynamic? Attribute { get; set; }

		public Func<string, string>? OnSelectItem { get; set; }

		public Func<string, dynamic>? ItemAttribute { get; set; }
	}
}
