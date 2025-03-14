// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace SmartCommerce.Infrastructure.Common.Models
{
	[Serializable]
	public class AddressInfoJsonModel
	{
		[JsonProperty("name_vi")]
		public string VietnameseName { get; set; } = string.Empty;

		[JsonProperty("name_en")]
		public string EnglishName { get; set; } = string.Empty;
	}
}
