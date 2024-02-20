// Copyright (c) 2024 - Jun Dev. All rights reserved

using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Controllers;
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
        /// Set default view value
        /// </summary>
        private void SetDefaultViewValue()
        {
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
            foreach(var error in validationResult.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }

        /// <summary>Session</summary>
        protected ISession Session
        {
            get
            {
                return HttpContext.Session;
            }
        }
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
    }
}
