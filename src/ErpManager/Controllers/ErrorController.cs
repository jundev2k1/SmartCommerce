// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Controllers
{
	public sealed class ErrorController : BaseController
	{
		private readonly IMailSender _mailSender;

		/// <summary>
		/// Constructor
		/// </summary>
		public ErrorController(
			ILocalizer localizer,
			IServiceFacade serviceFacade,
			SessionManager sessionManager,
			IFileLogger logger,
			IMailSender mail) : base(serviceFacade, sessionManager, localizer, logger)
		{
			_mailSender = mail;
		}

		[HttpGet]
		[AllowAnonymous]
		[Route(Constants.MODULE_ERROR_ERROR_PATH, Name = Constants.MODULE_ERROR_ERROR_NAME)]
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Index()
		{
			var (errorCode, errorMessage) = GetErrorSession();
			var content = GetPageContent(errorCode, errorMessage);

			_logger.LogError(content.Message);
			ClearErrorInfoSession();
			return View(content);
		}

		/// <summary>
		/// Get error session
		/// </summary>
		/// <returns>Error message</returns>
		private Tuple<ErrorCodeEnum, string> GetErrorSession()
		{
			// Get error message key
			var errorMessageKey = _sessionManager.SystemPageErrorMessage;
			var errorMessage = _localizer.Messages[errorMessageKey].Value;

			// Get error code
			var errorCodeString = _sessionManager.SystemPageErrorCode;
			var errorCode = string.IsNullOrEmpty(errorCodeString) == false
				? EnumUtility.GetEnumValue<ErrorCodeEnum>(errorCodeString)
				: ErrorCodeEnum.SystemError;

			return Tuple.Create(errorCode, errorMessage);
		}

		/// <summary>
		/// Get page content
		/// </summary>
		/// <param name="code">Error code</param>
		/// <param name="message">Error message</param>
		/// <returns>Page content</returns>
		private ErrorPageViewModel GetPageContent(ErrorCodeEnum code, string message)
		{
			var keyCode = code switch
			{
				ErrorCodeEnum.SystemError => Constants.ERRORMSG_KEY_SYSTEM_ERROR_CODE,
				ErrorCodeEnum.NotPermission => Constants.ERRORMSG_KEY_NO_HAS_PERMISSION_CODE,
				ErrorCodeEnum.DataNotFound => Constants.ERRORMSG_KEY_DATA_NOT_FOUND_CODE,
				ErrorCodeEnum.TokenInvalid => Constants.ERRORMSG_KEY_TOKEN_INVALID_CODE,
				ErrorCodeEnum.AnonymousAccess => Constants.ERRORMSG_KEY_ANONYMOUS_ACCESS_CODE,
				_ => Constants.ERRORMSG_KEY_SYSTEM_ERROR_CODE
			};
			var title = _localizer.Messages[keyCode].Value;

			if (string.IsNullOrEmpty(message))
			{
				var feature = HttpContext.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature>();
				var exception = feature?.Error;
				message = string.IsNullOrEmpty(exception?.Message)
					? _localizer.Messages.GetString(Constants.ERRORMSG_KEY_SYSTEM_ERROR)
					: exception.Message;
			}

			return new ErrorPageViewModel
			{
				Title = title,
				Message = message
			};
		}

		/// <summary>
		/// Clear error info session
		/// </summary>
		private void ClearErrorInfoSession()
		{
			// Clear error message
			_sessionManager.Remove(Constants.SESSION_KEY_PAGE_ERROR_MESSAGE);

			// Clear error code
			_sessionManager.Remove(Constants.SESSION_KEY_PAGE_ERROR_CODE);
		}
	}
}
