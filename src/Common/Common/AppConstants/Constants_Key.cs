// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace Common.Constants
{
    public static partial class Constants
    {
        /// <summary>Global key: Language code (for localization in page)</summary>
        public const string GLOBAL_KEY_LANGUAGE_CODE = "Language_Code";
        /// <summary>Global key: Title (for title every page)</summary>
        public const string GLOBAL_KEY_TITLE = "Title";
        /// <summary>Global key: Current page (for active menu)</summary>
        public const string GLOBAL_KEY_CURRENT_PAGE = "Current_Page";
        /// <summary>Global key: Operator permisson</summary>
        public const string GLOBAL_KEY_OPERATOR_PERMISSON = "Operator_Permisson";

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
    }
}
