﻿// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Domain.Enum
{
	public enum Permission
	{
		// Administrator permission
		HasAllPermission = 9999,

		// System permission
		CanAccessDashBoard = 1,

		// Role permission
		CanReadListRole = 20,
		CanReadDetailRole = 21,
		CanEditRole = 23,
		CanDeleteRole = 24,

		// User permission
		CanReadListUser = 50,
		CanReadDetailUser = 51,
		CanCreateUser = 52,
		CanEditUser = 53,
		CanDeleteUser = 54,
		CanImportUser = 55,
		CanExportUser = 56,
		CanReadPreviewUser = 57,

		// User role permission
		CanReadUserDetailRole = 70,
		CanEditUserRole = 71,

		// Product permission
		CanReadListProduct = 100,
		CanReadDetailProduct = 101,
		CanCreateProduct = 102,
		CanEditProduct = 103,
		CanDeleteProduct = 104,
		CanImportProduct = 105,
		CanExportProduct = 106,
		CanUploadImageProduct = 107,
		CanDeleteImageProduct = 108,
		CanSharePreviewProduct = 109,

		// Product category permission
		CanReadProductCategory = 120,
		CanAddProductCategory = 121,
		CanEditProductCategory = 122,
		CanDeleteProductCategory = 123,
	}
}
