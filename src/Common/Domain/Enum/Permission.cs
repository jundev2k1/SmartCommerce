// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Enum
{
    public enum Permission
    {
        // Administrator permission
        HasAllPermission = 9999,

        // System permission
        CanAccessDashBoard = 1,

        // Role permission
        CanAccessRole = 20,
        CanReadListRole = 21,
        CanReadDetailRole = 22,
        CanEditRole = 24,
        CanDeleteRole = 25,

        // User permission
        CanAccessUser = 50,
        CanReadListUser = 51,
        CanReadDetailUser = 52,
        CanCreateUser = 53,
        CanEditUser = 54,
        CanDeleteUser = 55,
        CanImportUser = 56,
        CanExportUser = 57,
        CanReadPreviewUser = 58,

        // User role permission
        CanAccessUserRole = 70,
        CanReadUserDetailRole = 71,
        CanEditUserRole = 72,

        // Product permission
        CanAccessProduct = 100,
        CanReadListProduct = 101,
        CanReadDetailProduct = 102,
        CanCreateProduct = 103,
        CanEditProduct = 104,
        CanDeleteProduct = 105,
        CanImportProduct = 106,
        CanExportProduct = 107,
        CanReadPreviewProduct = 108,
    }
}
