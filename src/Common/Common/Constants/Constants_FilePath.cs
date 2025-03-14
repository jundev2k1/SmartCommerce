// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Common
{
	public static partial class Constants
	{
		/// <summary>Physical path root</summary>
		public static string PHYSICAL_APPLICATION_SITE_PATH = string.Empty;
		public static string PHYSICAL_APPLICATION_ROOT_PATH = "wwwroot";
		public static string PHYSICAL_APPLICATION_CONTENT_PATH = Path.Combine(PHYSICAL_APPLICATION_SITE_PATH, PHYSICAL_APPLICATION_ROOT_PATH);

		/// <summary>Directory path: Sidebar setting</summary>
		public static string SCM_REFRESH_DIR_PATH = Path.Combine(PHYSICAL_APPLICATION_CONTENT_PATH, "refresh");

		/// <summary>File path: Sidebar setting</summary>
		public static string SCM_FILE_PATH_SIDEBAR_SETTING = "/Data/sidebar.json";
		/// <summary>File path: Value text setting</summary>
		public static string SCM_FILE_PATH_VALUETEXT_SETTING = "/Data/ValueText.json";

		/// <summary>File path: Data address provinces</summary>
		public static string FILE_PATH_DATA_ADDRESS_VN_PROVINCES = "/Data/Address/Vietnam/Provinces.json";
		/// <summary>File path: Data address districts</summary>
		public static string FILE_PATH_DATA_ADDRESS_VN_DISTRICTS = "/Data/Address/Vietnam/Districts.json";
		/// <summary>File path: Data address communes</summary>
		public static string FILE_PATH_DATA_ADDRESS_VN_COMMUNES = "/Data/Address/Vietnam/Communes.json";

		/// <summary>Manager File upload directory path</summary>
		public static string SCM_FILE_UPLOAD_DIRPATH_PRODUCT_IMAGES = @"wwwroot\content\uploads\product-images";
		public static string SCM_FILE_UPLOAD_DIRPATH_TEMP_PRODUCT_IMAGES = @"wwwroot\content\uploads\temp\product-images";
		public static string SCM_FILE_UPLOAD_DIRPATH_USER_AVATAR = @"wwwroot\content\uploads\user-avatars";
		public static string SCM_FILE_UPLOAD_DIRPATH_TEMP_USER_AVATAR = @"wwwroot\content\uploads\temp\user-avatars";
		public static string SCM_FILE_UPLOAD_DIRPATH_MEMBER_AVATAR = @"wwwroot\content\uploads\member-avatars";
		public static string SCM_FILE_UPLOAD_DIRPATH_TEMP_MEMBER_AVATAR = @"wwwroot\content\uploads\temp\member-avatars";

		/// <summary>File path: Js component nav bar</summary>
		public const string SCM_FILE_PATH_JS_COMPONENT_NAV_BAR = "~/js/component-script/Navbar/index.js";
		/// <summary>File path: Js component nav bar</summary>
		public const string SCM_FILE_PATH_JS_COMPONENT_UPLOAD_MULTIPLE_IMAGE = "~/js/component-script/UploadMultipleImage/index.js";
		/// <summary>File path: Js component search input</summary>
		public const string SCM_FILE_PATH_JS_COMPONENT_SEARCH_INPUT = "~/js/component-script/SearchInput/index.js";

		/// <summary>File path: Public no image placeholder</summary>
		public const string SCM_FILE_PATH_PUBLIC_LOGO = "~/content/images/system/logo.png";
		public const string SCM_FILE_PATH_PUBLIC_NO_IMAGE = "~/content/images/system/no-image-placeholder.jpg";
		public const string SCM_FILE_PATH_PUBLIC_NO_AVATAR = "~/content/images/system/no-user-placeholder.jpg";
	}
}
