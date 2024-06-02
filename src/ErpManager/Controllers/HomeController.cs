// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Controllers
{
    public sealed class HomeController : BaseController
    {
        private readonly ILocalizer _localizer;
        private readonly IServiceFacade _serviceFacade;
        private readonly SessionManager _sessionManager;

        /// <summary>
        /// Constructor
        /// </summary>
        public HomeController(ILocalizer localizer, IServiceFacade serviceFacade, SessionManager sessionManager)
            : base (serviceFacade, sessionManager)
        {
            _localizer = localizer;
            _serviceFacade = serviceFacade;
            _sessionManager = sessionManager;
        }

        /// <summary>
        /// Dashboard page
        /// </summary>
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
            var message = _sessionManager.Get(Constants.SESSION_KEY_LOGIN_MESSAGE);
            if (string.IsNullOrEmpty(message)) return;

            ViewBag.LoginMessage = message;
            _sessionManager.Remove(Constants.SESSION_KEY_LOGIN_MESSAGE);
        }

        [HttpGet]
        [Route("/change-language", Name = "ChangeLanguage")]
        public IActionResult LanguageSwitcher(string culture, string returnUrl)
        {
            // Set cookie option
            var cookieOption = new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1)
            };

            // Set cookie with chosen language
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                cookieOption);

            return Redirect(returnUrl);
        }


    }
}