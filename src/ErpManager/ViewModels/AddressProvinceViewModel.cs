// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Manager.ViewModels
{
	[Serializable]
	public sealed class AddressProvinceViewModel
	{
		[JsonProperty("id")]
		public string ProvinceId { get; set; } = string.Empty;

		[JsonProperty("name_vi")]
		public string VietnameseName { get; set; } = string.Empty;

		[JsonProperty("name_en")]
		public string EnglishName { get; set; } = string.Empty;

		public string PlateCode { get; set; } = string.Empty;
	}
}
