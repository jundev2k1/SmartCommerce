// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Common
{
	public static partial class Constants
	{
		/// <summary>Flag global culture: Vietnamese</summary>
		public const string FLG_GLOBAL_CULTURE_VN = "vi-VN";
		/// <summary>Flag global culture: English</summary>
		public const string FLG_GLOBAL_CULTURE_ENG = "en-US";
		/// <summary>Flag global culture: Japanese</summary>
		public const string FLG_GLOBAL_CULTURE_JP = "ja-JP";

		/// <summary>Mail ID: Mail to send OTP authentication for user</summary>
		public const string FLG_MAIL_ID_OTP_AUTH_MAIL = "Mail000001";
		/// <summary>Mail ID: Mail to send contact for administrator</summary>
		public const string FLG_MAIL_ID_CONTACT_ADMIN = "Mail100001";
		/// <summary>Mail ID: Mail to send report for administrator</summary>
		public const string FLG_MAIL_ID_REPORT_MAIL = "Mail100002";

		/// <summary>Product value text field: Status</summary>
		public const string VALUETEXT_FIELD_PRODUCT_STATUS = "status";
		/// <summary>Product status flag: Sold</summary>
		public const string FLG_PRODUCT_STATUS_SOLD = "0";
		/// <summary>Product status flag: Normal</summary>
		public const string FLG_PRODUCT_STATUS_NORMAL = "1";
		/// <summary>Product status flag: Good price</summary>
		public const string FLG_PRODUCT_STATUS_GOODPRICE = "2";
		/// <summary>Product status flag: Urgent sale</summary>
		public const string FLG_PRODUCT_STATUS_URGENTSALE = "3";
		/// <summary>Product status flag: pending</summary>
		public const string FLG_PRODUCT_STATUS_PENDING = "4";

		/// <summary>Product value text field: display price</summary>
		public const string VALUETEXT_FIELD_PRODUCT_DISPLAY_PRICE = "display_price";
		/// <summary>Product display price flag: Price 1</summary>
		public const string FLG_PRODUCT_DISPLAYPRICE_1 = "0";
		/// <summary>Product display price flag: Price 2</summary>
		public const string FLG_PRODUCT_DISPLAYPRICE_2 = "1";
		/// <summary>Product display price flag: Price 3</summary>
		public const string FLG_PRODUCT_DISPLAYPRICE_3 = "2";

		/// <summary>Product value text field: delete flag</summary>
		public const string VALUETEXT_FIELD_PRODUCT_DELFLG = "del_flg";
		/// <summary>Product delete flag: None</summary>
		public const string FLG_PRODUCT_DELFLG_NONE = "0";
		/// <summary>Product delete flag: Deleted</summary>
		public const string FLG_PRODUCT_DELFLG_DELETED = "1";

		/// <summary>User value text field: Status</summary>
		public const string VALUETEXT_FIELD_USER_STATUS = "status";
		/// <summary>User status flag: Inactive</summary>
		public const string FLG_USER_STATUS_INACTIVE = "0";
		/// <summary>User status flag: Active</summary>
		public const string FLG_USER_STATUS_ACTIVE = "1";

		/// <summary>User value text field: Sex</summary>
		public const string VALUETEXT_FIELD_USER_SEX = "sex";
		/// <summary>User sex flag: Male</summary>
		public const string FLG_USER_SEX_INACTIVE = "0";
		/// <summary>User sex flag: Female</summary>
		public const string FLG_USER_SEX_ACTIVE = "1";
		/// <summary>User sex flag: Other</summary>
		public const string FLG_USER_SEX_OTHER = "2";

		/// <summary>User value text field: delete flag</summary>
		public const string VALUETEXT_FIELD_USER_DELFLG = "del_flg";
		/// <summary>User delete flag: None</summary>
		public const string FLG_USER_DELFLG_NONE = "0";
		/// <summary>User delete flag: Deleted</summary>
		public const string FLG_USER_DELFLG_DELETED = "1";

		/// <summary>Common value text field: Form contact</summary>
		public const string VALUETEXT_FIELD_COMMON_FORM_CONTACT = "form_contact";
		/// <summary>Common form contact flag: Report</summary>
		public const string FLG_COMMON_FORMCONTACT_REPORT = "0";
		/// <summary>Common form contact flag: Contact the administrator</summary>
		public const string FLG_COMMON_FORMCONTACT_CONTACTADMIN = "1";
	}
}
