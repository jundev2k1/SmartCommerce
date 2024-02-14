// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.ERP.Message;

namespace ErpManager.ERP.Controllers
{
    public sealed class ErrorController : BaseController
    {
        private readonly IStringLocalizer<MessageLocalizer> _localizer;

        /// <summary>
        /// Constructor
        /// </summary>
        public ErrorController(IStringLocalizer<MessageLocalizer> localizer)
        {
            _localizer = localizer;
        }

        [HttpGet]
        [Route(Constants.MODULE_ERROR_ERROR_PATH, Name = Constants.MODULE_ERROR_ERROR_NAME)]
        public IActionResult Index()
        {
            var (errorCode, errorMessage) = GetErrorSession();
            if (errorCode is ErrorCodeEnum.NoError)
            {
                return RedirectToRoute(Constants.MODULE_HOME_DASHBOARD_NAME);
            }

            var content = GetPageContent(errorCode, errorMessage);

            return View(content);
        }

        /// <summary>
        /// Get error session
        /// </summary>
        /// <returns>Error message</returns>
        private Tuple<ErrorCodeEnum, string> GetErrorSession()
        {
            // Get error message
            var errorMessage = HttpContext
                .Session
                .GetString(Constants.SESSION_KEY_PAGE_ERROR_MESSAGE)
                .ToStringOrEmpty();

            // Get error code
            var errorCodeString = HttpContext
                .Session
                .GetString(Constants.SESSION_KEY_PAGE_ERROR_CODE)
                .ToStringOrEmpty();
            var errorCode = (string.IsNullOrEmpty(errorCodeString) == false)
                ? EnumUtility.GetEnumValue<ErrorCodeEnum>(errorCodeString)
                : ErrorCodeEnum.NoError;

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
            var title = code switch
            {
                ErrorCodeEnum.SystemError => _localizer[Constants.ERRORMSG_KEY_SYSTEM_ERROR_CODE],
                ErrorCodeEnum.NotPermission => _localizer[Constants.ERRORMSG_KEY_NO_HAS_PERMISSION_CODE],
                _ => string.Empty
            };

            return new ErrorPageViewModel
            {
                Title = title,
                Message = _localizer[message]
            };
        }
    }
}
