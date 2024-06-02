// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Infrastructure.Common.Middleware;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace ErpManager.ERP.Common.Middleware
{
    public class PermissionHandlerMiddleware : HandlerMiddlewareBase
    {
        /// <summary>DI</summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// Constructor
        /// </summary>
        public PermissionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context">Context</param>
        /// <returns>Next step or redirect to error page</returns>
        public async Task Invoke(HttpContext context)
        {
            // Check route permission
            var operatorPermission = context.Session.GetString(Constants.SESSION_KEY_OPERATOR_PERMISSION).ToStringOrEmpty();
            if (string.IsNullOrEmpty(operatorPermission))
            {
                if (this.IsValidRoute(context.Request.Path.Value.ToStringOrEmpty()) == false)
                {
                    context.Response.Redirect(Constants.MODULE_AUTH_SIGNIN_PATH);
                }

                await _next(context);
                return;
            }

            // Next if allow operator permission
            var permissionList = operatorPermission.Split(",");
            var result = (HasAllPermission(permissionList.First()) || HasPermission(context, permissionList));
            if (result)
            {
                await _next(context);
                return;
            }

            // Get message
            var messageKey = Constants.ERRORMSG_KEY_NO_HAS_PERMISSION;
            var errorMessage = MessageUtilitiy.GetMessageReplacer(messageKey);

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
        /// <param name="operatorPermissions">Operator permission</param>
        /// <returns>Has permission</returns>
        private bool HasPermission(HttpContext context, string[] operatorPermissions)
        {
            var pagePermission = GetPagePermission(context);
            return string.IsNullOrEmpty(pagePermission) || operatorPermissions.Contains(pagePermission);
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
            if ((permission == null) || (permission.Value == Permission.NonePermission))
                return string.Empty;

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
