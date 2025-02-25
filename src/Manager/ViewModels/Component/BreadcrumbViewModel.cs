// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewModels
{
	public sealed class BreadcrumbViewModel
	{
		public string Title { get; set; } = string.Empty;

		public string Href { get; set; } = string.Empty;

		public bool IsDisabled { get; set; }
	}
}
