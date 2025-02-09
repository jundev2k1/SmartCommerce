// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewModels
{
	public sealed class MenuViewModel
	{
		[JsonProperty]
		public int Priority { get; set; }

		[JsonProperty("label")]
		public string Label { get; set; } = string.Empty;

		[JsonProperty("name")]
		public string Name { get; set; } = string.Empty;

		[JsonProperty("permission")]
		public string Permission { get; set; } = string.Empty;

		[JsonProperty("localizer")]
		public string Localizer { get; set; } = string.Empty;

		[JsonProperty("icon")]
		public string Icon { get; set; } = string.Empty;

		[JsonProperty("url")]
		public string Url { get; set; } = string.Empty;

		[JsonProperty("items")]
		public List<SubMenuViewModel> Items { get; set; } = new List<SubMenuViewModel>();
	}

	public sealed class SubMenuViewModel
	{
		[JsonProperty("label")]
		public string Label { get; set; } = string.Empty;

		[JsonProperty("localizer")]
		public string Localizer { get; set; } = string.Empty;

		[JsonProperty("name")]
		public string Name { get; set; } = string.Empty;

		[JsonProperty("permission")]
		public string Permission { get; set; } = string.Empty;

		[JsonProperty("url")]
		public string Url { get; set; } = string.Empty;
	}
}
