// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.Areas.Roles.ViewModels
{
	public sealed class RoleSettingInfoRequestViewModel
	{
		[JsonProperty("roleId")]
		public int RoleId { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; } = string.Empty;

		[JsonProperty("description")]
		public string Description { get; set; } = string.Empty;

		[JsonProperty("status")]
		public int Status { get; set; }

		[JsonProperty("priority")]
		public int Priority { get; set; }
	}

	public sealed class RoleSettingPermissionRequestViewModel
	{
		[JsonProperty("roleId")]
		public int RoleId { get; set; }

		[JsonProperty("pageDefault")]
		public string PageDefault { get; set; } = Constants.PAGE_DEFAULT;

		[JsonProperty("permission")]
		public string Permission { get; set; } = string.Empty;
	}
}
