// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.ERP.Common;

namespace ErpManager.ERP.Controllers
{
    public sealed class ErrorController : BaseController
    {
        private readonly ILocalizer _localizer;

        /// <summary>
        /// Constructor
        /// </summary>
        public ErrorController(ILocalizer localizer)
        {
            _localizer = localizer;
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
            var errorMessageKey = Session.GetString(Constants.SESSION_KEY_PAGE_ERROR_MESSAGE).ToStringOrEmpty();

            // Get error code
            var errorCodeString = Session.GetString(Constants.SESSION_KEY_PAGE_ERROR_CODE).ToStringOrEmpty();
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
            Session.Remove(Constants.SESSION_KEY_PAGE_ERROR_MESSAGE);

            // Clear error code
            Session.Remove(Constants.SESSION_KEY_PAGE_ERROR_CODE);
        }
    }
}
