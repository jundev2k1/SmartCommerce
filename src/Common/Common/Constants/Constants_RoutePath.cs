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
		// Auth module: OTP authentication
		public const string MODULE_AUTH_OTP_PATH = "/otp-auth";
		public const string MODULE_AUTH_OTP_NAME = "OtpAuth";

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
		public const string MODULE_USER_USERDETAIL_PATH = "/user/detail/{id}";
		public const string MODULE_USER_USERDETAIL_NAME = "UserDetail";
		// User endpoint
		public const string ENDPOINT_COMMON_USER_GET_USER_LIST = "/common/get-users";

		// Role module: role area
		public const string MODULE_ROLE_AREA = "roles";
		// Role module: role list
		public const string MODULE_ROLE_ROLELIST_PATH = "/role/list";
		public const string MODULE_ROLE_ROLELIST_NAME = "RoleList";
		// Role module: role setting
		public const string MODULE_ROLE_ROLESETTING_PATH = "/role/setting/{id?}";
		public const string MODULE_ROLE_ROLESETTING_NAME = "RoleSetting";
		// Role module: role detail
		public const string MODULE_ROLE_ROLEDETAIL_PATH = "/role/detail/{id}";
		public const string MODULE_ROLE_ROLEDETAIL_NAME = "RoleDetail";

		// Product module
		public const string MODULE_PRODUCT_AREA = "products";
		// Product module: product list
		public const string MODULE_PRODUCT_PRODUCTLIST_PATH = "/product/list";
		public const string MODULE_PRODUCT_PRODUCTLIST_NAME = "ProductList";
		// Product module: product detail
		public const string MODULE_PRODUCT_PRODUCTDETAIL_PATH = "/product/detail/{id}";
		public const string MODULE_PRODUCT_PRODUCTDETAIL_NAME = "ProductDetail";
		// Product module: product register
		public const string MODULE_PRODUCT_PRODUCTREGISTER_PATH = "/product/register";
		public const string MODULE_PRODUCT_PRODUCTREGISTER_NAME = "ProductRegister";
		// Product module: product edit
		public const string MODULE_PRODUCT_PRODUCTEDIT_PATH = "/product/edit/{id}";
		public const string MODULE_PRODUCT_PRODUCTEDIT_NAME = "ProductEdit";
		// Product module: product edit description
		public const string MODULE_PRODUCT_PRODUCTEDIT_DESCRIPTION_PATH = "/product/edit-desc";
		public const string MODULE_PRODUCT_PRODUCTEDIT_DESCRIPTION_NAME = "ProductEditDescription";
		// Product module: product delete
		public const string MODULE_PRODUCT_PRODUCTDELETE_PATH = "/product/delete/{id}";
		public const string MODULE_PRODUCT_PRODUCTDELETE_NAME = "ProductDelete";
		// Product module: product preview
		public const string MODULE_PRODUCT_PRODUCTPREVIEW_PATH = "/product/preview";
		public const string MODULE_PRODUCT_PRODUCTPREVIEW_NAME = "ProductPreview";

		// Common endpoint: Change language
		public const string ENDPOINT_COMMON_CHANGE_LANGUAGE_PATH = "/change-language";
		public const string ENDPOINT_COMMON_CHANGE_LANGUAGE_NAME = "ChangeLanguage";
		// Common endpoint: Get address
		public const string ENDPOINT_COMMON_GET_PROVINCE_LIST = "/common/get-provinces";
		public const string ENDPOINT_COMMON_GET_DISTRICT_LIST = "/common/get-districts";
		public const string ENDPOINT_COMMON_GET_COMMUNE_LIST = "/common/get-communes";
		// Common endpoint: Upload images
		public const string ENDPOINT_COMMON_GET_SRC_IMAGES = "/common/get-src-images";
		public const string ENDPOINT_COMMON_UPLOAD_IMAGES = "/common/upload-images";
		public const string ENDPOINT_COMMON_UPDATE_NEWEST_IMAGES = "/common/update-newest-image";
		public const string ENDPOINT_COMMON_DELETE_IMAGE = "/common/delete-image";
		// Common endpoint: QR code
		public const string ENDPOINT_COMMON_GENERATE_QR_CODE = "/common/generate-qr-code";
	
		// Common endpoint: Mail
		public const string ENDPOINT_COMMON_MAIL_SENDMAIL_CONTACT_OPERATOR = "/mail/send-mail-to-operator";
	}
}
