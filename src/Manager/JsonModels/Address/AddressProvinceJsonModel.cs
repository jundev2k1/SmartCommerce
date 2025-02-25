// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.JsonModels
{
	[Serializable]
	public sealed class AddressProvinceJsonModel : AddressInfoJsonModel
	{
		[JsonProperty("id")]
		public string ProvinceId { get; set; } = string.Empty;

		[JsonProperty("plateCode")]
		public string PlateCode { get; set; } = string.Empty;
	}
}
