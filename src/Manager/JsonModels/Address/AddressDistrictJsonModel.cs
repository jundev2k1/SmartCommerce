// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.JsonModels
{
	public sealed class AddressDistrictGroupJsonModel
	{
		[JsonProperty("parentId")]
		public string ProvinceId { get; set; } = string.Empty;

		[JsonProperty("items")]
		public AddressDistrictJsonModel[] Items { get; set; } = Array.Empty<AddressDistrictJsonModel>();
	}

	public sealed class AddressDistrictJsonModel : AddressInfoJsonModel
	{
		[JsonProperty("id")]
		public string DistrictId { get; set; } = string.Empty;
	}
}
