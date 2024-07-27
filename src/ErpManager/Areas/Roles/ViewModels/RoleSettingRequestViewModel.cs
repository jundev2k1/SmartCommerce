// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Areas.Roles.ViewModels
{
	public sealed class RoleSettingInfoRequestViewModel
	{
		[JsonProperty("roleId")]
		public int RoleId { get; set; }

		[JsonProperty("roleName")]
		public string Name { get; set; } = string.Empty;

		[JsonProperty("roleDescription")]
		public string Description { get; set; } = string.Empty;

		[JsonProperty("roleStatus")]
		public string Status { get; set; } = string.Empty;

		[JsonProperty("rolePriority")]
		public string Priority { get; set; } = string.Empty;
	}

	public sealed class RoleSettingPermissionRequestViewModel
	{
		[JsonProperty("roleId")]
		public int RoleId { get; set; }

		[JsonProperty("rolePageDefault")]
		public string PageDefault { get; set; } = Constants.PAGE_DEFAULT;

		[JsonProperty("rolePermission")]
		public string Permission { get; set; } = string.Empty;
	}
}
