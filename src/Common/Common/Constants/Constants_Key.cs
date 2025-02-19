// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Common
{
	public static partial class Constants
	{
		/// <summary>Global key: Title (for title every page)</summary>
		public const string GLOBAL_KEY_TITLE = "Title";
		/// <summary>Global key: Current page (for active menu)</summary>
		public const string GLOBAL_KEY_CURRENT_PAGE = "Current_Page";
		/// <summary>Global key: Operator permisson</summary>
		public const string GLOBAL_KEY_OPERATOR_PERMISSON = "Operator_Permisson";
		/// <summary>Global key: Session token</summary>
		public const string GLOBAL_KEY_SESSION_TOKEN = "Session_Token";

		/// <summary>Session key: Operator branch id</summary>
		public const string SESSION_KEY_OPERATOR_BRANCH_ID = "Session_OperatorBranchId";
		/// <summary>Session key: Operator id</summary>
		public const string SESSION_KEY_OPERATOR_ID = "Session_OperatorId";
		/// <summary>Session key: Operator name</summary>
		public const string SESSION_KEY_OPERATOR_NAME = "Session_OperatorName";
		/// <summary>Session key: Operator permission</summary>
		public const string SESSION_KEY_OPERATOR_PERMISSION = "Session_OperatorPermission";
		/// <summary>Session key: Login message</summary>
		public const string SESSION_KEY_LOGIN_MESSAGE = "Session_LoginMessage";
		/// <summary>Session key: Page error code</summary>
		public const string SESSION_KEY_PAGE_ERROR_CODE = "Session_ErrorCode";
		/// <summary>Session key: Page error message</summary>
		public const string SESSION_KEY_PAGE_ERROR_MESSAGE = "Session_PageErrorMessage";

		/// <summary>Cookie key: Login remember me</summary>
		public const string COOKIE_KEY_LOGIN_REMEMBER_ME = "Cookie_Login_RememberMe";
		/// <summary>Cookie key: Login username</summary>
		public const string COOKIE_KEY_LOGIN_USERNAME = "Cookie_Login_Username";
		/// <summary>Cookie key: Login password</summary>
		public const string COOKIE_KEY_LOGIN_PASSWORD = "Cookie_Login_Password";
		/// <summary>Cookie key: Login count</summary>
		public const string COOKIE_KEY_LOGIN_COUNT = "Cookie_LoginCount_{0}";

		/// <summary>View data key: Auth error message</summary>
		public const string VIEWDATA_KEY_AUTH_ERROR_MESSAGE = "Auth_Error_Message";

		/// <summary>Param key: For page index</summary>
		public const string PARAM_KEY_PAGE_INDEX = "page";

		/// <summary>Upload key: For actual product images</summary>
		public const string UPLOAD_KEY_PRODUCT = "product";
		/// <summary>Upload key: For actual user images</summary>
		public const string UPLOAD_KEY_USER = "user";
		/// <summary>Upload key: For actual employee avatar images</summary>
		public const string UPLOAD_KEY_MEMBER = "employee";

		/// <summary>Token key: Expiration date</summary>
		public const string TOKEN_KEY_EXPIRATION_DATE = "expiration_date";

		// Mail sender data key
		public const string MAILDATA_KEY_TITLE = "mail-title";
		public const string MAILDATA_KEY_MAIL_TO_EMAIL = "mail-to-email";
		public const string MAILDATA_KEY_MAIL_TO_NAME = "mail-to-name";
		public const string MAILDATA_KEY_MAIL_TO_TEL = "mail-to-tel";
		public const string MAILDATA_KEY_MAIL_TO_ADDRESS = "mail-to-address";
		public const string MAILDATA_KEY_MAIL_FROM_EMAIL = "mail-from-email";
		public const string MAILDATA_KEY_MAIL_FROM_NAME = "mail-from-name";
		public const string MAILDATA_KEY_MAIL_FROM_TEL = "mail-from-tel";
		public const string MAILDATA_KEY_MAIL_FROM_ADDRESS = "mail-from-address";
		public const string MAILDATA_KEY_MAIL_PARAGRAPH = "mail-paragraph";
		public const string MAILDATA_KEY_MAIL_LOOP_FROM = "mail-loop-email-from";
		public const string MAILDATA_KEY_MAIL_LOOP_TO = "mail-loop-email-to";
		public const string MAILDATA_KEY_MAIL_LOOP_PRODUCT_ID = "mail-loop-product-id";
		public const string MAILDATA_KEY_MAIL_LOOP_PRODUCT_NAME = "mail-loop-product-name";
		public const string MAILDATA_KEY_MAIL_LOOP_PRODUCT_PRICE1 = "mail-loop-product-price1";
		public const string MAILDATA_KEY_MAIL_LOOP_PRODUCT_PRICE2 = "mail-loop-product-price2";
		public const string MAILDATA_KEY_MAIL_LOOP_PRODUCT_PRICE3 = "mail-loop-product-price3";

		public const string MAILTAG_MAIL_LOOP = "mail-loops";
		public const string MAILTAG_MAIL_LOOP_LAST_ITEM_IGNORE = "mail-loop-last-item-ignore";
		public const string MAILTAG_MAIL_PARAGRAPH_ITEM = "mail-paragraph-item";

		// Request key: Common
		public const string REQUEST_KEY_PAGE_NO = "page";
		public const string REQUEST_KEY_PAGE_SIZE = "cnt";
		public const string REQUEST_KEY_KEYWORD = "kwrd";

		// Request key: Product module
		public const string REQUEST_KEY_PRODUCT_BRAND_ID = "bid";
		public const string REQUEST_KEY_PRODUCT_PRODUCT_ID = "pid";
		public const string REQUEST_KEY_PRODUCT_PRODUCT_NAME = "pname";
		public const string REQUEST_KEY_PRODUCT_ADDRESS1 = "addr1";
		public const string REQUEST_KEY_PRODUCT_ADDRESS2 = "addr2";
		public const string REQUEST_KEY_PRODUCT_ADDRESS3 = "addr3";
		public const string REQUEST_KEY_PRODUCT_ADDRESS4 = "addr4";
		public const string REQUEST_KEY_PRODUCT_PRICE_TYPE = "pt";
		public const string REQUEST_KEY_PRODUCT_MIN_PRICE1 = "minpr1";
		public const string REQUEST_KEY_PRODUCT_MAX_PRICE1 = "maxpr1";
		public const string REQUEST_KEY_PRODUCT_MIN_PRICE2 = "minpr2";
		public const string REQUEST_KEY_PRODUCT_MAX_PRICE2 = "maxpr2";
		public const string REQUEST_KEY_PRODUCT_MIN_PRICE3 = "minpr3";
		public const string REQUEST_KEY_PRODUCT_MAX_PRICE3 = "maxpr3";
		public const string REQUEST_KEY_PRODUCT_MIN_SIZE1 = "minsz1";
		public const string REQUEST_KEY_PRODUCT_MAX_SIZE1 = "maxsz1";
		public const string REQUEST_KEY_PRODUCT_MIN_SIZE2 = "minsz2";
		public const string REQUEST_KEY_PRODUCT_MAX_SIZE2 = "maxsz2";
		public const string REQUEST_KEY_PRODUCT_MIN_SIZE3 = "minsz3";
		public const string REQUEST_KEY_PRODUCT_MAX_SIZE3 = "maxsz3";
		public const string REQUEST_KEY_PRODUCT_TAKE_OVER_ID = "toid";
		public const string REQUEST_KEY_PRODUCT_STATUS = "status";
		public const string REQUEST_KEY_PRODUCT_CATEGORY_ID = "cateid";
		public const string REQUEST_KEY_PRODUCT_DELETE_FLG = "del";
		public const string REQUEST_KEY_PRODUCT_DATE_CHANGED_FROM = "dchf";
		public const string REQUEST_KEY_PRODUCT_DATE_CHANGED_TO = "dcht";
		public const string REQUEST_KEY_PRODUCT_DATE_CREATED_FROM = "dcrt";
		public const string REQUEST_KEY_PRODUCT_DATE_CREATED_TO = "dcrt";
	}
}
