// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Controllers
{
    public class HomeController : BaseController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public HomeController()
        {
        }

        /// <summary>
        /// Dashboard page
        /// </summary>
        /// <returns></returns>
        [PermissionAttribute(Permission.CanAccessDashBoard)]
        [Route("/", Name = Constants.MODULE_HOME_DASHBOARD_NAME)]
        [Route(Constants.MODULE_HOME_DASHBOARD_PATH)]
        public IActionResult Index()
        {
            HandleForLoginSuccess();

            return View();
        }

        /// <summary>
        /// Handle for login success
        /// </summary>
        private void HandleForLoginSuccess()
        {
            var message = Session.GetString(Constants.SESSION_KEY_LOGIN_MESSAGE);
            if (string.IsNullOrEmpty(message)) return;

            ViewBag.LoginMessage = message;
            Session.Remove(Constants.SESSION_KEY_LOGIN_MESSAGE);
        }
    }
}