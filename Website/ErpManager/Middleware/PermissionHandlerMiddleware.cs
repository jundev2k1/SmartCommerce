using Common.Constants;
using Common.Utilities;
using Domain.Enum;
using Microsoft.Extensions.Localization;
using System.Reflection;

namespace ErpManager.Web.Middleware
{
    public class PermissionHandlerMiddleware
    {
        /// <summary>DI</summary>
        private readonly RequestDelegate _next;
        private readonly IStringLocalizer<GlobalLocalizer> _localizer;
        private readonly AppConfiguration _configuration;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="next">Next</param>
        /// <param name="localizer">Localizer</param>
        /// <param name="configuration">Configuration</param>
        public PermissionHandlerMiddleware(RequestDelegate next, IStringLocalizer<GlobalLocalizer> localizer, AppConfiguration configuration)
        {
            _next = next;
            _localizer = localizer;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            var permission = context.Session.GetString(Constants.SESSION_KEY_OPERATOR_PERMISSION).ToStringOrEmpty();
            if (string.IsNullOrEmpty(permission))
            {
                if (context.Request.Path.Value != "/login")
                {
                    context.Response.Redirect("/login");
                }

                await _next(context);
                return;
            }

            // Next if allow permission
            var result = HasAllPermission(permission) || HasPermission(context, permission);
            if (result)
            {
                await _next(context);
                return;
            }

            // Get message
            var message = _localizer.GetString("ErrorMessage_NoHasPermission");
            var errorMessage = MessageUtilitiy.GetMessageReplacer(message);

            // Clear and set error message for error page
            context.Session.Clear();
            context.Session.SetString(Constants.SESSION_KEY_PAGE_ERROR_MESSAGE, errorMessage);
            context.Response.Redirect("/error-page");
        }

        /// <summary>
        /// Has all permission
        /// </summary>
        /// <param name="permission">Permission</param>
        /// <returns>Has all permision</returns>
        private bool HasAllPermission(string permission)
        {
            var result = int.TryParse(permission, out var allPermisson);
            if (result)
            {
                return allPermisson == (int)Permission.HasAllPermission;
            }

            return false;
        }

        /// <summary>
        /// Has permission
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="permission">Permission</param>
        /// <returns>Has permission</returns>
        private bool HasPermission(HttpContext context, string permission)
        {
            var route = context.GetRouteValue("action").ToStringOrEmpty();
            var actionMethod = context.GetType().GetMethod(route);
            if (actionMethod == null) return false;

            var permissionAttribute = actionMethod.GetCustomAttribute<PermissionAttribute>();
            if (permissionAttribute == null) return false;

            var permissionValue = permissionAttribute.Permission;

            return true;
        }
    }
}
