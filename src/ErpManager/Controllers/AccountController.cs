// Copyright (c) 2024 - Jun Dev. All rights reserved

using AutoMapper;
using Common.Constants;
using Common.Utilities;
using Domain.Models;
using ErpManager.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Persistence.Common;
using System.Collections;

namespace ErpManager.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<GlobalLocalizer> _localizer;
        private readonly IServices _services;

        public AccountController(IStringLocalizer<GlobalLocalizer> localizer, IMapper mapper, IServices services)
        {
            _localizer = localizer;
            _mapper = mapper;
            _services = services;
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
                return RedirectToRoute(Constants.MODULE_HOME_DASHBOARD_NAME);
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
                var user = _services.Users.GetUserByUsername(this.OperatorBrandID, input.LoginID);
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
                var isSuccess = _services.Users.TryLogin(this.OperatorBrandID, input.LoginID, input.Password);
                if (isSuccess == false) throw new Exception();

                // Handle login success
                HandleLoginSuccess(user, input.RememberMe);
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
        /// <param name="user">User model</param>
        /// <param name="isRememberMe">Is remember me</param>
        private void HandleLoginSuccess(UserModel user, bool isRememberMe)
        {
            // Reset login count
            ResetLoginCount(user.UserId);

            // Set session login for operator
            SetSessionForLogin(user);
            ResetOperatorSession();

            // Handle with cookies
            if (isRememberMe == false)
            {
                DeleteCookies();
                return;
            }

            CreateCookies(user);
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
                var message = _localizer.GetString(Constants.ERRORMSG_KEY_LOGIN_TOO_MUCH);
                errorMessage = MessageUtilitiy.GetMessageReplacer(message, replacer);

            }
            else
            {
                var message = _localizer.GetString(Constants.ERRORMSG_KEY_LOGIN_FAILED);
                errorMessage = MessageUtilitiy.GetMessageReplacer(message);
            }

            SetErrorMessage(errorMessage);
        }

        /// <summary>
        /// Set session for login
        /// </summary>
        /// <param name="user"></param>
        private void SetSessionForLogin(UserModel user)
        {
            // Set session login for operator
            Session.SetString(Constants.SESSION_KEY_OPERATOR_ID, user.UserId);
            Session.SetString(Constants.SESSION_KEY_OPERATOR_PERMISSION, "9999");
            Session.SetString(Constants.SESSION_KEY_LOGIN_MESSAGE, "Login success");
        }

        /// <summary>
        /// Create cookies
        /// </summary>
        /// <param name="user">User model</param>
        private void CreateCookies(UserModel user)
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
            Response.Cookies.Append(Constants.COOKIE_KEY_LOGIN_USERNAME, user.UserName, cookieOptions);
            Response.Cookies.Append(Constants.COOKIE_KEY_LOGIN_PASSWORD, user.Password, cookieOptions);
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
                    Password = cookies[Constants.COOKIE_KEY_LOGIN_PASSWORD].ToStringOrEmpty(),
                    RememberMe = (string.IsNullOrEmpty(rememberMeCookie) == false),
                };
            }
        }
    }
}
