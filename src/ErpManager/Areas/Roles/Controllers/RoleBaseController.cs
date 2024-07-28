// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Manager.Areas.Roles.ViewModels;

namespace ErpManager.Manager.Areas.Roles.Controllers
{
	public class RoleBaseController : BaseController
	{
		protected readonly ValueTextManager _valueTextManager;

		public RoleBaseController(
			IServiceFacade serviceFacade,
			SessionManager sessionManager,
			ILocalizer localizer,
			IFileLogger logger,
			ValueTextManager valueTextManager) : base(serviceFacade, sessionManager, localizer, logger)
		{
			_valueTextManager = valueTextManager;
		}

		/// <summary>
		/// Get init dropdown list items
		/// </summary>
		/// <param name="formInput">Form input</param>
		/// <returns>Dropdown list item collection</returns>
		protected RoleInputOptionViewModel GetInitDropdownListItems(RoleModel formInput)
		{
			return new RoleInputOptionViewModel();
		}

		/// <summary>
		/// Get permission group collection
		/// </summary>
		/// <returns>Permission group collection</returns>
		protected List<RolePermissionGroupViewModel> GetPermissionGroupCollection()
		{
			var createPermissionInfo = (Permission permission) =>
			{
				return (permission.ToString(), permission.ToString());
			};

			var createPermissionGroup = (KeyValuePair<string, List<(string Name, Permission Permission)>> permission) =>
			{
				var permissionList = permission.Value
					.Select(perm => (perm.Name, ((int)perm.Permission).ToString()))
					.ToList();

				return new RolePermissionGroupViewModel
				{
					GroupName = permission.Key,
					PermissionList = permissionList,
				};
			};

			var result = PermissionGroups.Select(createPermissionGroup).ToList();
			return result;
		}

		private Dictionary<string, List<(string, Permission)>> PermissionGroups = new Dictionary<string, List<(string, Permission)>>
		{
			// Role Permission
			{
				"role-permission",
				new List<(string, Permission)>
				{
					("Read List Role", Permission.CanReadListRole),
					("Read Detail Role", Permission.CanReadDetailRole),
					("Edit Role", Permission.CanEditRole),
					("Delete Role", Permission.CanDeleteRole),
				}
			},
			// User Permission
			{
				"user-permission",
				new List<(string, Permission)>
				{
					("Read List User", Permission.CanReadListUser),
					("Read Detail User", Permission.CanReadDetailUser),
					("Create User", Permission.CanCreateUser),
					("Edit User", Permission.CanEditUser),
					("Delete User", Permission.CanDeleteUser),
					("Import User", Permission.CanImportUser),
					("Export User", Permission.CanExportUser),
					("Read Preview User", Permission.CanReadPreviewUser),
				}
			},
			// Product Permission
			{
				"product-permission",
				new List<(string, Permission)>
				{
					("Read Product List", Permission.CanReadListProduct),
					("Read Detail Product", Permission.CanReadDetailProduct),
					("Create Product", Permission.CanCreateProduct),
					("Edit Product", Permission.CanEditProduct),
					("Delete Product", Permission.CanDeleteProduct),
					("Import Product", Permission.CanImportProduct),
					("Export Product", Permission.CanExportProduct),
					("Upload Image Product", Permission.CanUploadImageProduct),
					("Delete Image Product", Permission.CanDeleteImageProduct),
					("Share Preview Product", Permission.CanSharePreviewProduct),
				}
			}
		};
	}
}
