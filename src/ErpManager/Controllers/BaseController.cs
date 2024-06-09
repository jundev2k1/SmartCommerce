// Copyright (c) 2024 - Jun Dev. All rights reserved

using FluentValidation.Results;
using System.Reflection;

namespace ErpManager.ERP.Controllers
{
    public class BaseController : Controller
    {
        private readonly IServiceFacade _serviceFacade;
        private readonly SessionManager _sessionManager;

        /// <summary>
        /// Base Controller Constructor
        /// </summary>
        public BaseController(IServiceFacade serviceFacade, SessionManager sessionManager)
        {
            _serviceFacade = serviceFacade;
            _sessionManager = sessionManager;
            Initialize();
        }

        /// <summary>
        /// Initialize
        /// </summary>
        private void Initialize()
        {
            SetPropertiesValue();
            SetDefaultViewValue();
        }

        /// <summary>
        /// Has All Permission
        /// </summary>
        /// <param name="permissions">Permission collection</param>
        /// <returns>Has all permission?</returns>
        protected bool HasAllPermission(params Permission[] permissions)
        {
            if (this.OperatorPermission.Any() == false) return false;

            var result = this.OperatorPermission.Contains(Permission.HasAllPermission.GetStringValue())
                || permissions.All(permission => this.OperatorPermission.Contains(permission.GetStringValue()));
            return result;
        }

        /// <summary>
        /// Has any permission
        /// </summary>
        /// <param name="permissions">Permission collection</param>
        /// <returns>Has any permission?</returns>
        protected bool HasAnyPermission(params Permission[] permissions)
        {
            if (this.OperatorPermission.Any() == false) return false;

            var result = this.OperatorPermission.Contains(Permission.HasAllPermission.GetStringValue())
                || permissions.Any(permission => this.OperatorPermission.Contains(permission.GetStringValue()));
            return result;
        }

        /// <summary>
        /// Has permission
        /// </summary>
        /// <param name="permission">Permission collection</param>
        /// <returns>Has permission?</returns>
        protected bool HasPermission(Permission permission)
        {
            if (this.OperatorPermission.Any() == false) return false;

            var result = this.OperatorPermission.Contains(Permission.HasAllPermission.GetStringValue())
                || this.OperatorPermission.Contains(permission.GetStringValue());
            return result;
        }

        /// <summary>
        /// Reset operator session
        /// </summary>
        protected void ResetOperatorSession()
        {
            this.OperatorBranchId = _sessionManager.OperatorBranchId;
            this.OperatorId = _sessionManager.OperatorId;
            this.OperatorName = _sessionManager.OperatorName;
            this.OperatorPermission = _sessionManager.OperatorPermission
                ?.Split(',', StringSplitOptions.RemoveEmptyEntries)
                ?? Array.Empty<string>();
        }

        /// <summary>
        /// Clear session
        /// </summary>
        protected void ClearSession()
        {
            _sessionManager.ClearAll();
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
                Constants.UPLOAD_KEY_MEMBER => UploadEnum.MemberAvatar,
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
        /// Get or reset session id
        /// </summary>
        /// <returns>Session id</returns>
        private string GetOrResetSessionId()
        {
            var result = _sessionManager.Get(Constants.GLOBAL_KEY_SESSION_TOKEN);
            if (string.IsNullOrEmpty(result) == false) return result;

            var newId = Guid.NewGuid().ToString();
            _sessionManager.Set(Constants.GLOBAL_KEY_SESSION_TOKEN, newId);
            return newId;
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
            _sessionManager.SystemPageErrorCode = errorCode.GetStringValue();
            _sessionManager.SystemPageErrorMessage = errorMessageKey;

            return RedirectToRoute(Constants.MODULE_ERROR_ERROR_NAME);
        }

        /// <summary>Operator branch id</summary>
        protected string OperatorBranchId { get; private set; } = Constants.CONFIG_MASTER_BRANCH_ID;
        /// <summary>Operator id</summary>
        protected string OperatorId { get; private set; } = string.Empty;
        /// <summary>Operator name</summary>
        protected string OperatorName { get; private set; } = string.Empty;
        /// <summary>Operator Permission</summary>
        protected string[] OperatorPermission { get; private set; } = Array.Empty<string>();
        /// <summary>Session token</summary>
        protected string SessionToken => GetOrResetSessionId();
    }
}
