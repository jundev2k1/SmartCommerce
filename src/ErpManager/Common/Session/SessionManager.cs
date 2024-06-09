// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Common.Session
{
    public sealed class SessionManager : SessionManagerBase
    {
        public SessionManager(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor) { }

        /// <summary>Is login</summary>
        public bool IsLogin { get { return !string.IsNullOrEmpty(Get(Constants.SESSION_KEY_OPERATOR_ID)); }}

        /// <summary>Branch id</summary>
        public string OperatorBranchId
        {
            get { return Get(Constants.SESSION_KEY_OPERATOR_BRANCH_ID); }
            set { Set(Constants.SESSION_KEY_OPERATOR_BRANCH_ID, value); }
        }

        /// <summary>Operator id</summary>
        public string OperatorId
        {
            get { return Get(Constants.SESSION_KEY_OPERATOR_ID); }
            set { Set(Constants.SESSION_KEY_OPERATOR_ID, value); }
        }

        /// <summary>Operator id</summary>
        public string OperatorName
        {
            get { return Get(Constants.SESSION_KEY_OPERATOR_NAME); }
            set { Set(Constants.SESSION_KEY_OPERATOR_NAME, value); }
        }

        /// <summary>Operator Permission</summary>
        public string OperatorPermission
        {
            get { return Get(Constants.SESSION_KEY_OPERATOR_PERMISSION); }
            set { Set(Constants.SESSION_KEY_OPERATOR_PERMISSION, value); }
        }
        /// <summary>System page error code</summary>
        public string SystemPageErrorCode
        {
            get { return Get(Constants.SESSION_KEY_PAGE_ERROR_CODE); }
            set { Set(Constants.SESSION_KEY_PAGE_ERROR_CODE, value); }
        }
        /// <summary>System page error message</summary>
        public string SystemPageErrorMessage
        {
            get { return Get(Constants.SESSION_KEY_PAGE_ERROR_MESSAGE); }
            set { Set(Constants.SESSION_KEY_PAGE_ERROR_MESSAGE, value); }
        }
    }
}
