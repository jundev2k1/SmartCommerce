// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Infrastructure.Common.Enum;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

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
            SetPropertiesValue();
            SetDefaultViewValue();
        }

        /// <summary>
        /// Reset operator session
        /// </summary>
        protected void ResetOperatorSession()
        {
            this.OperatorBranchId = Session.GetString(Constants.SESSION_KEY_OPERATOR_BRANCH_ID).ToStringOrEmpty();
            this.OperatorId = Session.GetString(Constants.SESSION_KEY_OPERATOR_ID).ToStringOrEmpty();
            this.OperatorName = Session.GetString(Constants.SESSION_KEY_OPERATOR_NAME).ToStringOrEmpty();
            this.OperatorPermission = Session.GetString(Constants.SESSION_KEY_OPERATOR_PERMISSION).ToStringOrEmpty();
        }

        /// <summary>
        /// Clear session
        /// </summary>
        protected void ClearSession()
        {
            Session.Clear();
        }

        /// <summary>
        /// Get type upload by string
        /// </summary>
        /// <param name="typeUpload">Type upload</param>
        /// <returns>Type upload by string</returns>
        protected static UploadEnum GetTypeUploadByString(string typeUpload)
        {
            return typeUpload switch
            {
                Constants.UPLOAD_KEY_PRODUCT => UploadEnum.ProductImage,
                Constants.UPLOAD_KEY_USER => UploadEnum.UserAvatar,
                Constants.UPLOAD_KEY_EMPLOYEE => UploadEnum.EmployeeAvatar,
                _ => UploadEnum.None
            };
        }

        /// <summary>
        /// Get page permission
        /// </summary>
        /// <returns>Page permission</returns>
        protected List<RouteAttribute?> GetFeaturesPagePermission()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var controllerTypes = assembly.GetTypes().Where(type =>
                typeof(Controller).IsAssignableFrom(type)
                && (type.FullName.ToStringOrEmpty().Contains("Home")
                    || type.FullName.ToStringOrEmpty().Contains("Areas")));
            var featuresRoutes = controllerTypes
                .SelectMany(type => type
                    .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                    .Where(childType =>
                        (childType.GetCustomAttribute<PermissionAttribute>() != null))
                    .Select(childType => childType
                        .GetCustomAttributes<RouteAttribute>()
                        .FirstOrDefault(route => route.Name != null)))
                .Distinct()
                .ToList();

            return featuresRoutes;
        }

        /// <summary>
        /// Set default page data
        /// </summary>
        private void SetDefaultPageData()
        {
            this.PageUrl = Request.Path;
        }

        /// <summary>
        /// Set properties value
        /// </summary>
        private void SetPropertiesValue()
        {
        }

        /// <summary>
        /// Set default view value
        /// </summary>
        private void SetDefaultViewValue()
        {
            ViewData[Constants.GLOBAL_KEY_SESSION_TOKEN] = this.SessionToken;
        }

        /// <summary>
        /// Get or reset session id
        /// </summary>
        /// <returns>Session id</returns>
        private string GetOrResetSessionId()
        {
            var result = this.Session.GetString(Constants.GLOBAL_KEY_SESSION_TOKEN);
            if (result != null) return result;

            var newId = Guid.NewGuid().ToString();
            this.Session.SetString(Constants.GLOBAL_KEY_SESSION_TOKEN, newId);
            return newId;
        }

        /// <summary>
        /// Add error to model state
        /// </summary>
        /// <param name="validationResult">Validation result</param>
        protected void AddErrorToModelState(ValidationResult validationResult)
        {
            // Clear model state
            ModelState.Clear();

            // Add message fluent validate for model state
            foreach (var error in validationResult.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }

        /// <summary>
        /// Redirect to error page
        /// </summary>
        /// <param name="errorMessageKey">Error message key</param>
        /// <param name="errorCode">Error code</param>
        protected IActionResult RedirectToErrorPage(
            string errorMessageKey = Constants.ERRORMSG_KEY_SYSTEM_ERROR,
            ErrorCodeEnum errorCode = ErrorCodeEnum.SystemError)
        {
            Session.SetString(Constants.SESSION_KEY_PAGE_ERROR_CODE, errorCode.GetStringValue<int>());
            Session.SetString(Constants.SESSION_KEY_PAGE_ERROR_MESSAGE, errorMessageKey);

            return RedirectToRoute(Constants.MODULE_ERROR_ERROR_NAME);
        }

        /// <summary>Session</summary>
        protected ISession Session => HttpContext.Session;
        /// <summary>Operator branch id</summary>
        protected string OperatorBranchId { get; private set; } = Constants.CONFIG_DEFAULT_BRANCH_ID;
        /// <summary>Operator id</summary>
        protected string OperatorId { get; private set; } = string.Empty;
        /// <summary>Operator id</summary>
        protected string OperatorName { get; private set; } = string.Empty;
        /// <summary>Operator id</summary>
        protected string OperatorPermission { get; private set; } = string.Empty;
        /// <summary>Page url</summary>
        protected string PageUrl { get; private set; } = string.Empty;
        /// <summary>Operator id</summary>
        protected string OperatorPermissions { get; private set; } = string.Empty;
        /// <summary>Session token</summary>
        protected string SessionToken => GetOrResetSessionId();
    }
}
