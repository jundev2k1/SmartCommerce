// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Controllers
{
    public sealed class AuthenticationController : BaseController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AuthenticationController(
            ILocalizer localizer,
            IServiceFacade serviceFacade,
            SessionManager sessionManager,
            IFileLogger logger)
            : base (serviceFacade, sessionManager, localizer, logger)
        {
        }

        [HttpGet]
        [Route("/dang-nhap")]
        [Route(Constants.MODULE_AUTH_SIGNIN_PATH, Name = Constants.MODULE_AUTH_SIGNIN_NAME)]
        public IActionResult Index()
        {
            if (!this.LoginCookieInput.RememberMe) return View(new LoginViewModel());

            return View(this.LoginCookieInput);
        }

        [HttpPost]
        [Route("/dang-nhap")]
        [Route(Constants.MODULE_AUTH_SIGNIN_PATH, Name = Constants.MODULE_AUTH_SIGNIN_NAME)]
        public IActionResult Index(LoginViewModel login)
        {
            var isSuccess = HandleTryLogin(login);
            if (isSuccess)
            {
                var featuresPage = GetFeaturesPagePermission();
                if (featuresPage.Any(page => page?.Name.ToStringOrEmpty() == Constants.MODULE_HOME_DASHBOARD_NAME))
                {
                    return RedirectToRoute(Constants.MODULE_HOME_DASHBOARD_NAME);
                }

                var route = featuresPage.FirstOrDefault()?.Name;
                if (route != null) return RedirectToRoute(route);
            }

            return View(login);
        }

        /// <summary>
        /// Get login count
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns>Login count</returns>
        private int GetLoginCount(string userId)
        {
            var key = string.Format(Constants.COOKIE_KEY_LOGIN_COUNT, userId);
            var loginCount = Request.Cookies[key].ToStringOrEmpty();

            // Parse fail, count = 0
            int.TryParse(loginCount, out var count);

            return count;
        }

        /// <summary>
        /// Increase login count
        /// </summary>
        /// <param name="userId">User id</param>
        private void IncreaseLoginCount(string userId)
        {
            // Get login count
            var loginCount = GetLoginCount(userId) + 1;

            // Add login cookies
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.UtcNow.AddMinutes(Constants.AUTH_LOGIN_COUNT_EXPIRES),
                HttpOnly = true,
                Secure = true,
            };
            var key = string.Format(Constants.COOKIE_KEY_LOGIN_COUNT, userId);
            // Delete and create new key cookies
            Response.Cookies.Delete(key);
            Response.Cookies.Append(key, loginCount.ToString(), cookieOptions);
        }

        /// <summary>
        /// Reset login count
        /// </summary>
        /// <param name="userId">User id</param>
        private void ResetLoginCount(string userId)
        {
            var key = string.Format(Constants.COOKIE_KEY_LOGIN_COUNT, userId);

            // Delete cookie
            Response.Cookies.Delete(key);
        }

        /// <summary>
        /// Is blocked authentication
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>Is blocked</returns>
        private bool IsBlockedAuth(string userId)
        {
            return GetLoginCount(userId) >= Constants.AUTH_LOGIN_COUNT_LIMIT;
        }

        /// <summary>
        /// Handle try login
        /// </summary>
        /// <param name="input">Login input</param>
        /// <returns>Is login success</returns>
        private bool HandleTryLogin(LoginViewModel input)
        {
            var isBlock = false;
            try
            {
                // Check login id is wrong
                var user = _serviceFacade.Users.GetUserByUsername(Constants.CONFIG_MASTER_BRANCH_ID, input.LoginID);
                if (user == null) throw new Exception();

                // Check block account
                if (IsBlockedAuth(user.UserId))
                {
                    isBlock = true;
                    throw new Exception();
                }
                // Increase login count every login after check block account
                IncreaseLoginCount(user.UserId);

                // Try login, throw error if login fail
                var passwordEncrypt = Authorization.Instance.PasswordEncrypt(input.Password);
                var @operator = _serviceFacade.Users.TryLogin(Constants.CONFIG_MASTER_BRANCH_ID, input.LoginID, passwordEncrypt);
                if (@operator == null) throw new Exception("Login information invalid");

                // Handle login success
                HandleLoginSuccess(@operator, input.RememberMe);
                return true;
            }
            catch
            {
                HandleLoginFail(isBlock);
                return false;
            }
        }

        /// <summary>
        /// Handle login success
        /// </summary>
        /// <param name="operator">Operator model</param>
        /// <param name="isRememberMe">Is remember me</param>
        private void HandleLoginSuccess(OperatorModel @operator, bool isRememberMe)
        {
            // Reset login count
            ResetLoginCount(@operator.Profile.UserId);

            // Set session login for operator
            SetSessionForLogin(@operator);
            ResetOperatorSession();

            // Handle with cookies
            if (isRememberMe == false)
            {
                DeleteCookies();
                return;
            }

            CreateCookies(@operator);
        }

        /// <summary>
        /// Handle login fail
        /// </summary>
        /// <param name="isBlock">Is block</param>
        private void HandleLoginFail(bool isBlock = false)
        {
            var errorMessage = string.Empty;
            if (isBlock)
            {
                var replacer = new Hashtable
                {
                    { "@@login_times@@", Constants.AUTH_LOGIN_COUNT_LIMIT },
                    { "@@login_expires@@", Constants.AUTH_LOGIN_COUNT_EXPIRES }
                };
                var message = _localizer.Messages.GetString(Constants.ERRORMSG_KEY_LOGIN_TOO_MUCH);
                errorMessage = MessageUtilitiy.GetMessageReplacer(message, replacer);

            }
            else
            {
                var message = _localizer.Messages.GetString(Constants.ERRORMSG_KEY_LOGIN_FAILED);
                errorMessage = MessageUtilitiy.GetMessageReplacer(message);
            }

            SetErrorMessage(errorMessage);
        }

        /// <summary>
        /// Set session for login
        /// </summary>
        /// <param name="operator">Operator model</param>
        private void SetSessionForLogin(OperatorModel @operator)
        {
            // Set session login for operator
            _sessionManager.OperatorBranchId = @operator.BranchId;
            _sessionManager.OperatorId = @operator.Profile.UserId;
            _sessionManager.OperatorName = @operator.Profile.FullName;
            _sessionManager.OperatorPermission = @operator.Permission;
            // Set login message
            _sessionManager.Set(
                Constants.SESSION_KEY_LOGIN_MESSAGE,
                (_localizer.Messages["Message_LoginSuccess"]?.Value).ToStringOrEmpty());
        }

        /// <summary>
        /// Create cookies
        /// </summary>
        /// <param name="operator">Operator model</param>
        private void CreateCookies(OperatorModel @operator)
        {
            // Add login cookies
            var cookieOptions = new CookieOptions
            {
                Path = "/",
                Expires = DateTime.Now.AddDays(Constants.AUTH_EXPIRES_COOKIE),
                HttpOnly = true,
                Secure = true,
                SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None
            };
            Response.Cookies.Append(Constants.COOKIE_KEY_LOGIN_REMEMBER_ME, "checked", cookieOptions);
            Response.Cookies.Append(Constants.COOKIE_KEY_LOGIN_USERNAME, @operator.Profile.UserName, cookieOptions);
            Response.Cookies.Append(Constants.COOKIE_KEY_LOGIN_PASSWORD, @operator.Profile.Password, cookieOptions);
        }

        /// <summary>
        /// Delete cookies
        /// </summary>
        private void DeleteCookies()
        {
            Response.Cookies.Delete(Constants.COOKIE_KEY_LOGIN_REMEMBER_ME);
            Response.Cookies.Delete(Constants.COOKIE_KEY_LOGIN_USERNAME);
            Response.Cookies.Delete(Constants.COOKIE_KEY_LOGIN_PASSWORD);
        }

        /// <summary>
        /// Set error message
        /// </summary>
        /// <param name="errorMessage">Error message</param>
        private void SetErrorMessage(string errorMessage)
        {
            ViewData[Constants.VIEWDATA_KEY_AUTH_ERROR_MESSAGE] = errorMessage;
        }

        /// <summary>
        /// Sign out
        /// </summary>
        /// <returns>Redirect to login page</returns>
        [HttpGet]
        [Route(Constants.MODULE_AUTH_SIGNOUT_PATH, Name = Constants.MODULE_AUTH_SIGNOUT_NAME)]
        public IActionResult LogOut()
        {
            ClearSession();
            return RedirectToRoute(Constants.MODULE_AUTH_SIGNIN_NAME);
        }

        /// <summary>Login cookie input</summary>
        private LoginViewModel LoginCookieInput
        {
            get
            {
                var cookies = Request.Cookies;
                var rememberMeCookie = cookies[Constants.COOKIE_KEY_LOGIN_REMEMBER_ME].ToStringOrEmpty();

                return new LoginViewModel
                {
                    LoginID = cookies[Constants.COOKIE_KEY_LOGIN_USERNAME].ToStringOrEmpty(),
                    Password = Authorization.Instance.PasswordDecrypt(
                        cookies[Constants.COOKIE_KEY_LOGIN_PASSWORD].ToStringOrEmpty()),
                    RememberMe = (string.IsNullOrEmpty(rememberMeCookie) == false),
                };
            }
        }
    }
}
