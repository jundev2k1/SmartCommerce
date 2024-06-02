// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Controllers
{
    public sealed class ErrorController : BaseController
    {
        private readonly ILocalizer _localizer;
        private readonly IServiceFacade _serviceFacade;
        private readonly SessionManager _sessionManager;

        /// <summary>
        /// Constructor
        /// </summary>
        public ErrorController(ILocalizer localizer, IServiceFacade serviceFacade, SessionManager sessionManager)
            : base(serviceFacade, sessionManager)
        {
            _localizer = localizer;
            _serviceFacade = serviceFacade;
            _sessionManager = sessionManager;
        }

        [HttpGet]
        [Route(Constants.MODULE_ERROR_ERROR_PATH, Name = Constants.MODULE_ERROR_ERROR_NAME)]
        public IActionResult Index()
        {
            var (errorCode, errorMessageKey) = GetErrorSession();
            var content = GetPageContent(errorCode, errorMessageKey);
            if (errorCode is ErrorCodeEnum.NoError)
            {
                return RedirectToRoute(Constants.MODULE_HOME_DASHBOARD_NAME);
            }

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
                : ErrorCodeEnum.NoError;

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

            return new ErrorPageViewModel
            {
                Title = title,
                Message = _localizer.Messages.GetString(messageKey)
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
