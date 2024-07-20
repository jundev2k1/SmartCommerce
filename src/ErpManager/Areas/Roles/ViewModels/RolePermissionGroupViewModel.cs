// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Areas.Roles.ViewModels
{
	public sealed class RolePermissionGroupViewModel
	{
		public string GroupName { get; set; } = string.Empty;

		public List<(string Name, string Value)> PermissionList { get; set; } = new List<(string, string)>();
	}
}
