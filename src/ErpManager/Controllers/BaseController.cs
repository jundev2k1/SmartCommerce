// Copyright (c) 2024 - Jun Dev. All rights reserved

using Microsoft.AspNetCore.Mvc.Filters;

namespace ErpManager.ERP.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// On action executing
        /// </summary>
        /// <param name="context">Context</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Initialize();
            base.OnActionExecuting(context);
        }

        /// <summary>
        /// Initialize
        /// </summary>
        private void Initialize()
        {
            SetDefaultPageData();
            SetDefaultViewValue();
        }

        /// <summary>
        /// Reset operator session
        /// </summary>
        public void ResetOperatorSession()
        {
            this.OperatorBrandID = Session.GetString(Constants.SESSION_KEY_OPERATOR_BRANCH_ID).ToStringOrEmpty();
            this.OperatorId = Session.GetString(Constants.SESSION_KEY_OPERATOR_ID).ToStringOrEmpty();
            this.OperatorName = Session.GetString(Constants.SESSION_KEY_OPERATOR_NAME).ToStringOrEmpty();
            this.OperatorPermission = Session.GetString(Constants.SESSION_KEY_OPERATOR_PERMISSION).ToStringOrEmpty();
        }

        /// <summary>
        /// Clear session
        /// </summary>
        public void ClearSession()
        {
            Session.Clear();
        }

        /// <summary>
        /// Set default page data
        /// </summary>
        private void SetDefaultPageData()
        {
            this.PageUrl = Request.Path;
        }

        /// <summary>
        /// Set default view value
        /// </summary>
        private void SetDefaultViewValue()
        {
        }

        /// <summary>Session</summary>
        public ISession Session
        {
            get
            {
                return HttpContext.Session;
            }
        }
        /// <summary>Operator brand id</summary>
        public string OperatorBrandID { get; private set; } = Constants.CONFIG_DEFAULT_BRANCH_ID;
        /// <summary>Operator id</summary>
        public string OperatorId { get; private set; } = string.Empty;
        /// <summary>Operator id</summary>
        public string OperatorName { get; private set; } = string.Empty;
        /// <summary>Operator id</summary>
        public string OperatorPermission { get; private set; } = string.Empty;
        /// <summary>Page url</summary>
        public string PageUrl { get; private set; } = string.Empty;
        /// <summary>Operator id</summary>
        public string OperatorPermissions { get; private set; } = string.Empty;
    }
}
