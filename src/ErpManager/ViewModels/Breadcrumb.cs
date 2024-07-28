// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Manager.ViewModels
{
	public sealed class Breadcrumb
	{
		public string Title { get; set; } = string.Empty;
		public string Href { get; set; } = string.Empty;
		public bool IsDisabled { get; set; }
	}
}
