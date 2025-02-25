// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.JsonModels
{
	public sealed class AddressCommuneGroupListJsonModel
	{
		[JsonProperty("provinceId")]
		public string ProvinceId { get; set; } = string.Empty;
		[JsonProperty("items")]
		public AddressCommuneGroupJsonModel[] Items { get; set; } = Array.Empty<AddressCommuneGroupJsonModel>();
	}

	public sealed class AddressCommuneGroupJsonModel
	{
		[JsonProperty("districtId")]
		public string DistrictId { get; set; } = string.Empty;
		[JsonProperty("items")]
		public AddressCommuneJsonModel[] Items { get; set; } = Array.Empty<AddressCommuneJsonModel>();
	}

	public sealed class AddressCommuneJsonModel : AddressInfoJsonModel
	{
		[JsonProperty("id")]
		public string CommuneId { get; set; } = string.Empty;
	}
}
