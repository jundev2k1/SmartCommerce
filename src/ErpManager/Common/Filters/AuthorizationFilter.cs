// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Common.Filters
{
	public sealed class AuthorizationFilter : IActionFilter
	{
		private readonly SessionManager _sessionManager;
		public AuthorizationFilter(SessionManager sessionManager)
		{
			_sessionManager = sessionManager;
		}

		private enum PermissionStatus
		{

		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			var endpoint = context.HttpContext.GetEndpoint();
			if (endpoint == null) return;

			var routeInfo = endpoint.Metadata.GetMetadata<RouteAttribute>();
			var isPublicRoute = (routeInfo != null) && this.PublicRoute.Contains(routeInfo.Template);
			if (isPublicRoute) return;

			var allowAnonymous = endpoint.Metadata.GetMetadata<AllowAnonymousAttribute>();
			if (allowAnonymous != null) return;

			var permission = endpoint.Metadata.GetMetadata<PermissionAttribute>();
			if (permission != null)
			{
				this.OperatorPermission = _sessionManager.OperatorPermissionList;
				this.RoutePermissions = permission.Permissions;
				if (HasPermission()) return;
			}

			// Get message
			var messageKey = Constants.ERRORMSG_KEY_NO_HAS_PERMISSION;
			var errorMessage = MessageUtilitiy.GetMessageReplacer(messageKey);

			// Clear and set error message for error page
			SetErrorMessage(errorMessage);
			context.Result = new RedirectResult(Constants.MODULE_ERROR_ERROR_PATH);
		}

		public void OnActionExecuted(ActionExecutedContext context)
		{
		}

		/// <summary>
		/// Has all permission
		/// </summary>
		/// <returns>Has all permision</returns>
		private bool HasPermission()
		{
			var result = this.OperatorPermission
				.Select(permission => EnumUtility.GetEnumValue<Permission>(permission))
				.Any(permission =>
					permission == Permission.HasAllPermission
					|| this.RoutePermissions.Contains(permission));
			return result;
		}

		/// <summary>
		/// Set error message
		/// </summary>
		/// <param name="message">Message</param>
		private void SetErrorMessage(string message)
		{
			_sessionManager.Set(Constants.SESSION_KEY_PAGE_ERROR_CODE, ErrorCodeEnum.NotPermission.GetStringValue());
			_sessionManager.Set(Constants.SESSION_KEY_PAGE_ERROR_MESSAGE, message);
		}

		private string[] OperatorPermission { get; set; } = Array.Empty<string>();
		/// <summary>Current route permission</summary>
		private Permission[] RoutePermissions { get; set; } = Array.Empty<Permission>();
		/// <summary>Public route</summary>
		private string[] PublicRoute => new string[]
		{
			Constants.MODULE_AUTH_SIGNIN_PATH,
			Constants.MODULE_ERROR_ERROR_PATH,
		};
	}
}
