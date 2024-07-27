// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Areas.Roles.ViewModels
{
	public sealed class RoleSettingViewModel
	{
		public RoleModel Information { get; set; } = new RoleModel();

		public List<RolePermissionGroupViewModel> PermissionGroups { get; set; } = new List<RolePermissionGroupViewModel>();

		public string SelectPermission { get; set; } = string.Empty;
		public RoleInputOptionViewModel InputOption { get; set; } = new RoleInputOptionViewModel();
	}
}
