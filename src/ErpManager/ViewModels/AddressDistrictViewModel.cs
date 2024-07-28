// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Manager.ViewModels
{
	public sealed class AddressDistrictGroupViewModel
	{
		[JsonProperty("parentId")]
		public string ProvinceId { get; set; } = string.Empty;

		[JsonProperty("items")]
		public AddressDistrictViewModel[] Items { get; set; } = Array.Empty<AddressDistrictViewModel>();
	}

	public sealed class AddressDistrictViewModel
	{
		[JsonProperty("id")]
		public string DistrictId { get; set; } = string.Empty;

		[JsonProperty("name_vi")]
		public string VietnameseName { get; set; } = string.Empty;

		[JsonProperty("name_en")]
		public string EnglishName { get; set; } = string.Empty;
	}
}
