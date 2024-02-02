using Common.Constants;
using Common.Utilities;
using Domain.Models;
using Domain.Services;
using ErpManager.Web;
using ErpManager.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.Net;

namespace ErpManager.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IStringLocalizer<GlobalLocalizer> _localizer;
        private readonly IUserService _userService;

        public AccountController(IStringLocalizer<GlobalLocalizer> localizer, IUserService userService)
        {
            _localizer = localizer;
            _userService = userService;
        }

        [Route("/dang-nhap")]
        [Route("/login", Name = "Login")]
        [HttpGet]
        public IActionResult Index()
        {
            if (this.LoginCookieInput.RememberMe)
            {
                var loginDefaultInput = HandleRememberMe();
                if (loginDefaultInput == null) return RedirectToRoute("Home");

                return View(loginDefaultInput);
            }

            return View(this.LoginCookieInput);
        }

        [Route("/dang-nhap")]
        [Route("/login", Name = "Login")]
        [HttpPost]
        public IActionResult Index(LoginViewModel login)
        {
            var user = _userService.TryLogin(login.LoginID, login.Password);
            if (user != null)
            {
                HandleLoginSuccess(user, login.RememberMe);
                return RedirectToRoute("Home");
            }

            ViewData["as"] = "";
            return View(this.LoginCookieInput);
        }

        /// <summary>
        /// Handle login success
        /// </summary>
        /// <param name="user">User model</param>
        /// <param name="isRememberMe">Is remember me</param>
        private void HandleLoginSuccess(UserModel user, bool isRememberMe)
        {
            // Set session login for operator
            var session = HttpContext.Session;
            session.SetString(Constants.SESSION_KEY_OPERATOR_ID, user.UserId);
            session.SetString(Constants.SESSION_KEY_OPERATOR_PERMISSION, "0");

            // Handle cookie
            HandleCookies(user, isRememberMe);
        }

        /// <summary>
        /// Handle cookies
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="isRememberMe">Is remember me</param>
        private void HandleCookies(UserModel? user, bool isRememberMe)
        {
            // Delete cookies
            if ((isRememberMe == false) || (user == null))
            {
                Response.Cookies.Delete(Constants.COOKIE_KEY_LOGIN_REMEMBER_ME);
                Response.Cookies.Delete(Constants.COOKIE_KEY_LOGIN_USERNAME);
                Response.Cookies.Delete(Constants.COOKIE_KEY_LOGIN_PASSWORD);
                return;
            }

            // Add login cookies
            var cookieOptions = new CookieOptions
            {
                Path = "/",
                Expires = DateTime.Now.AddDays(30),
                HttpOnly = true,
                Secure = true,
                SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None
            };
            Response.Cookies.Append(Constants.COOKIE_KEY_LOGIN_REMEMBER_ME, "checked", cookieOptions);
            Response.Cookies.Append(Constants.COOKIE_KEY_LOGIN_USERNAME, user.UserName, cookieOptions);
            Response.Cookies.Append(Constants.COOKIE_KEY_LOGIN_PASSWORD, user.Password, cookieOptions);
        }

        /// <summary>
        /// Handle remember me
        /// </summary>
        /// <returns>Login View Model or redirect page</returns>
        private LoginViewModel? HandleRememberMe()
        {
            if ((string.IsNullOrEmpty(this.LoginCookieInput.LoginID) == false)
                && (string.IsNullOrEmpty(this.LoginCookieInput.Password) == false))
            {
                var user = _userService.TryLogin(this.LoginCookieInput.LoginID, this.LoginCookieInput.Password);
                if (user != null)
                {
                    HandleLoginSuccess(user, this.LoginCookieInput.RememberMe);
                    return null;
                }
            }

            return this.LoginCookieInput;
        }

        /// <summary>
        /// Log out
        /// </summary>
        /// <returns>Redirect to login page</returns>
        [HttpGet]
        [Route("/logout", Name ="Logout")]
        public IActionResult LogOut()
        {
            // Delete cookies
            HandleCookies(null, false);

            // Clear session
            HttpContext.Session.Clear();

            return RedirectToRoute("Login");
        }

        /// <summary>Login cookie input</summary>
        private LoginViewModel LoginCookieInput
        {
            get
            {
                var cookies = Request.Cookies;
                var rememberMeCookie = Request.Cookies[Constants.COOKIE_KEY_LOGIN_REMEMBER_ME].ToStringOrEmpty();

                return new LoginViewModel
                {
                    LoginID = cookies[Constants.COOKIE_KEY_LOGIN_USERNAME].ToStringOrEmpty(),
                    Password = cookies[Constants.COOKIE_KEY_LOGIN_PASSWORD].ToStringOrEmpty(),
                    RememberMe = (string.IsNullOrEmpty(rememberMeCookie) == false),
                };
            }
        }
    }
}
