// Copyright (c) 2024 - Jun Dev. All rights reserved

using FluentValidation.Results;
using System.Reflection;

namespace SmartCommerce.Manager.Controllers
{
	public class BaseController : Controller
	{
		protected readonly IServiceFacade _serviceFacade;
		protected readonly SessionManager _sessionManager;
		protected readonly ILocalizer _localizer;
		protected readonly IFileLogger _logger;

		/// <summary>
		/// Base Controller Constructor
		/// </summary>
		public BaseController(
			IServiceFacade serviceFacade,
			SessionManager sessionManager,
			ILocalizer localizer,
			IFileLogger logger)
		{
			_serviceFacade = serviceFacade;
			_sessionManager = sessionManager;
			_localizer = localizer;
			_logger = logger;
			Initialize();
		}

		/// <summary>
		/// Initialize
		/// </summary>
		private void Initialize()
		{
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
						(childType.GetCustomAttribute<AuthorizationAttribute>() != null))
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
		/// Add error to model state
		/// </summary>
		/// <param name="validationResult">Validation result</param>
		protected void AddErrorToModelState(ValidationResult validationResult, string preName = "")
		{
			ModelState.Clear();
			// Set error message validate to Model State
			foreach (var error in validationResult.Errors)
			{
				var propName = $"{preName}{error.PropertyName}";
				ModelState.AddModelError(propName, error.ErrorMessage);
			}
		}

		/// <summary>
		/// Redirect to error page
		/// </summary>
		/// <param name="errorMessage">Error message</param>
		/// <param name="errorCode">Error code</param>
		protected IActionResult RedirectToErrorPage(
			string errorMessage,
			ErrorCodeEnum errorCode = ErrorCodeEnum.SystemError)
		{
			_sessionManager.SystemPageErrorCode = errorCode.GetStringValue();
			_sessionManager.SystemPageErrorMessage = errorMessage;

			return RedirectToRoute(Constants.MODULE_ERROR_ERROR_NAME);
		}

		/// <summary>
		/// Get request parameter value
		/// </summary>
		/// <typeparam name="T">Type of value</typeparam>
		/// <param name="key">Request key</param>
		/// <param name="defaultValue">Default value</param>
		/// <returns>Request parameter value</returns>
		protected T GetRequestParam<T>(string key, T defaultValue)
		{
			var hasParam = Request.Query.ContainsKey(key);
			if (!hasParam) return defaultValue;

			try
			{
				return (T)Convert.ChangeType(Request.Query[key].ToStringOrEmpty(), typeof(T));
			}
			catch
			{
				return defaultValue;
			}
		}

		/// <summary>Is login</summary>
		protected bool IsLogin => _sessionManager.IsLogin;
		/// <summary>Operator branch id</summary>
		protected string OperatorBranchId => _sessionManager.OperatorBranchId;
		/// <summary>Operator id</summary>
		protected string OperatorId => _sessionManager.OperatorId;
		/// <summary>Operator name</summary>
		protected string OperatorName => _sessionManager.OperatorName;
		/// <summary>Operator Permission</summary>
		protected string[] OperatorPermission => _sessionManager.OperatorPermission
			?.Split(',', StringSplitOptions.RemoveEmptyEntries)
			?? Array.Empty<string>();
		/// <summary>Session token</summary>
		protected string SessionToken => GetOrResetSessionId();
	}
}
