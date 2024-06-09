// Copyright (c) 2024 - Jun Dev. All rights reserved

using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;

namespace ErpManager.ERP.Controllers
{
    public sealed class ErrorController : BaseController
    {
        private readonly ILocalizer _localizer;
        private readonly IServiceFacade _serviceFacade;
        private readonly SessionManager _sessionManager;
        private readonly IFileLogger _logger;
        private readonly IMailSender _mail;

        /// <summary>
        /// Constructor
        /// </summary>
        public ErrorController(
            ILocalizer localizer,
            IServiceFacade serviceFacade,
            SessionManager sessionManager,
            IFileLogger logger,
            IMailSender mail) : base(serviceFacade, sessionManager)
        {
            _localizer = localizer;
            _serviceFacade = serviceFacade;
            _sessionManager = sessionManager;
            _logger = logger;
            _mail = mail;
        }

        [HttpGet]
        [Route(Constants.MODULE_ERROR_ERROR_PATH, Name = Constants.MODULE_ERROR_ERROR_NAME)]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index()
        {
            _mail.SendMailToOperator("Test mail", "<h1>Hello world</h1>\n<p>Hey you... I'm supper hacker. How do you feel</p>");
            var (errorCode, errorMessageKey) = GetErrorSession();
            var content = GetPageContent(errorCode, errorMessageKey);
            
            _logger.LogInformation("Test info message");
            _logger.LogWarning("Test warning message");
            _logger.LogError("Test error message");
            _logger.LogTrace("Test trace message");
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

            // Get error code
            var errorCodeString = _sessionManager.SystemPageErrorCode;
            var errorCode = string.IsNullOrEmpty(errorCodeString) == false
                ? EnumUtility.GetEnumValue<ErrorCodeEnum>(errorCodeString)
                : ErrorCodeEnum.SystemError;

            return Tuple.Create(errorCode, errorMessageKey);
        }

        /// <summary>
        /// Get page content
        /// </summary>
        /// <param name="code">Error code</param>
        /// <param name="messageKey">Error message key</param>
        /// <returns>Page content</returns>
        private ErrorPageViewModel GetPageContent(ErrorCodeEnum code, string messageKey)
        {
            var title = code switch
            {
                ErrorCodeEnum.SystemError => _localizer.Messages.GetString(Constants.ERRORMSG_KEY_SYSTEM_ERROR_CODE),
                ErrorCodeEnum.NotPermission => _localizer.Messages.GetString(Constants.ERRORMSG_KEY_NO_HAS_PERMISSION_CODE),
                _ => _localizer.Messages.GetString(Constants.ERRORMSG_KEY_SYSTEM_ERROR_CODE)
            };

            var message = _localizer.Messages.GetString(messageKey).ToStringOrEmpty();
            if (string.IsNullOrEmpty(message))
            {
                var feature = HttpContext.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature>();
                var exception = feature?.Error;
                message = (exception?.Message).ToStringOrEmpty();
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
