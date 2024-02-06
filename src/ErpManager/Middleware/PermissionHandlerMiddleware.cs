// Copyright (c) 2024 - Jun Dev. All rights reserved

using Common.Constants;
using Common.Utilities;
using Domain.Enum;
using ErpManager.Web.Enum;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Localization;
using System.Reflection;
using System.Security;

namespace ErpManager.Web.Middleware
{
    public class PermissionHandlerMiddleware : HandlerMiddlewareBase
    {
        /// <summary>DI</summary>
        private readonly RequestDelegate _next;
        private readonly IStringLocalizer<GlobalLocalizer> _localizer;
        private readonly AppConfiguration _configuration;

        /// <summary>
        /// Constructor
        /// </summary>
        public PermissionHandlerMiddleware(RequestDelegate next, IStringLocalizer<GlobalLocalizer> localizer, AppConfiguration configuration)
        {
            _next = next;
            _localizer = localizer;
            _configuration = configuration;
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context">Context</param>
        /// <returns>Next step or redirect to error page</returns>
        public async Task Invoke(HttpContext context)
        {
            var operatorPermission = context.Session.GetString(Constants.SESSION_KEY_OPERATOR_PERMISSION).ToStringOrEmpty();
            if (string.IsNullOrEmpty(operatorPermission))
            {
                if (this.PublicRoute.Contains(context.Request.Path.Value) == false)
                {
                    context.Response.Redirect(Constants.MODULE_AUTH_SIGNIN_PATH);
                }

                await _next(context);
                return;
            }

            // Next if allow operator permission
            var permissionList = operatorPermission.Split(",");
            var result = (HasAllPermission(operatorPermission) || HasPermission(context, permissionList));
            if (result)
            {
                await _next(context);
                return;
            }

            // Get message
            var message = _localizer.GetString(Constants.ERRORMSG_KEY_NO_HAS_PERMISSION);
            var errorMessage = MessageUtilitiy.GetMessageReplacer(message);

            // Clear and set error message for error page
            SetErrorMessage(context, errorMessage);
            context.Response.Redirect(Constants.MODULE_ERROR_ERROR_PATH);
        }

        /// <summary>
        /// Has all permission
        /// </summary>
        /// <param name="permission">Permission</param>
        /// <returns>Has all permision</returns>
        private bool HasAllPermission(string permission)
        {
            var result = EnumUtility.GetEnumValue<Permission>(permission);
            return result == Permission.HasAllPermission;
        }

        /// <summary>
        /// Has permission
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="operatorPermission">Operator permission</param>
        /// <returns>Has permission</returns>
        private bool HasPermission(HttpContext context, string[] operatorPermissions)
        {
            var pagePermission = GetPagePermission(context);
            return operatorPermissions.Contains(pagePermission);
        }

        /// <summary>
        /// Get page permission
        /// </summary>
        /// <returns>Page permission</returns>
        private string GetPagePermission(HttpContext context)
        {
            // Get attributes
            var attributes = context.GetEndpoint()
                ?.Metadata.GetMetadata<ControllerActionDescriptor>()
                ?.MethodInfo.GetCustomAttributes(inherit: true);
            // Find permission attribute
            var permission = attributes?
                .Where(attr => attr is PermissionAttribute)
                .Select(attr => (PermissionAttribute)attr)
                .FirstOrDefault()
                ?.Permission;
            if (permission == null) return string.Empty;

            return permission.GetStringValue<int>();
        }

        /// <summary>
        /// Set error message
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="message">Message</param>
        private void SetErrorMessage(HttpContext context, string message)
        {
            context.Session.Clear();
            context.Session.SetString(Constants.SESSION_KEY_PAGE_ERROR_CODE, ErrorCodeEnum.NotPermission.GetStringValue<int>());
            context.Session.SetString(Constants.SESSION_KEY_PAGE_ERROR_MESSAGE, message);
        }
    }
}
