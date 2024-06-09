// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Common
{
    public static partial class Constants
    {
        /// <summary>Flg global culture: Vietnamese</summary>
        public const string FLG_GLOBAL_CULTURE_VN = "vi-VN";
        /// <summary>Flg global culture: English</summary>
        public const string FLG_GLOBAL_CULTURE_ENG = "en-US";
        /// <summary>Flg global culture: Japanese</summary>
        public const string FLG_GLOBAL_CULTURE_JP = "ja-JP";

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

        /// <summary>Common value text field: Form contact</summary>
        public const string VALUETEXT_FIELD_COMMON_FORM_CONTACT = "form_contact";
        /// <summary>Common form contact flag: Report</summary>
        public const string FLG_COMMON_FORMCONTACT_REPORT = "0";
        /// <summary>Common form contact flag: Contact the administrator</summary>
        public const string FLG_COMMON_FORMCONTACT_CONTACTADMIN = "1";
    }
}
