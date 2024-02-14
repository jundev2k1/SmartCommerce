// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Common
{
    public static partial class Constants
    {
        // Auth module: sign in
        public const string MODULE_AUTH_SIGNIN_PATH = "/sign-in";
        public const string MODULE_AUTH_SIGNIN_NAME = "SignIn";
        // Auth module: sign out
        public const string MODULE_AUTH_SIGNOUT_PATH = "/sign-out";
        public const string MODULE_AUTH_SIGNOUT_NAME = "SignOut";

        // Error module: error
        public const string MODULE_ERROR_ERROR_PATH = "/error-page";
        public const string MODULE_ERROR_ERROR_NAME = "Error";

        // Home module: dashboard (home)
        public const string MODULE_HOME_HOME_PATH = "/";
        public const string MODULE_HOME_DASHBOARD_PATH = "/dashboard";
        public const string MODULE_HOME_DASHBOARD_NAME = "Dashboard";

        // User module: user area
        public const string MODULE_USER_AREA = "users";
        // User module: user list
        public const string MODULE_USER_USERLIST_PATH = "/user/list";
        public const string MODULE_USER_USERLIST_NAME = "UserList";
        // User module: user detail
        public const string MODULE_USER_USERDETAIL_PATH = "/user/detail";
        public const string MODULE_USER_USERDETAIL_NAME = "UserDetail";
        // User module: user role
        public const string MODULE_USER_USERROLE_PATH = "/user/role";
        public const string MODULE_USER_USERROLE_NAME = "UserRole";

        // Product module
        public const string MODULE_PRODUCT_AREA = "products";
        // Product module: product list
        public const string MODULE_PRODUCT_PRODUCTLIST_PATH = "/product/list";
        public const string MODULE_PRODUCT_PRODUCTLIST_NAME = "ProductList";
        // Product module: product detail
        public const string MODULE_PRODUCT_PRODUCTDETAIL_PATH = "/product/detail";
        public const string MODULE_PRODUCT_PRODUCTDETAIL_NAME = "ProductDetail";
        // Product module: product register
        public const string MODULE_PRODUCT_PRODUCTREGISTER_PATH = "/product/register";
        public const string MODULE_PRODUCT_PRODUCTREGISTER_NAME = "ProductRegister";
    }
}
