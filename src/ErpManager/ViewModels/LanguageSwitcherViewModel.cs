// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Manager.ViewModels
{
	public sealed class LanguageSwitcherViewModel
	{
		public string CurrentCulture { get; set; } = string.Empty;
		public CultureViewModel[] AvailableCultures { get; set; } = Array.Empty<CultureViewModel>();
	}

	public sealed class CultureViewModel
	{
		public string Culture { get; set; } = string.Empty;
		public string DisplayName { get; set; } = string.Empty;
	}
}
