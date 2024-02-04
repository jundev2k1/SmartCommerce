using Common.Constants;
using Common.Utilities;
using Domain.Enum;
using ErpManager.Web.Enum;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Localization;
using System.Reflection;
using System.Security;

namespace ErpManager.Web.Middleware
{
    public class HandlerMiddlewareBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public HandlerMiddlewareBase()
        {
        }

        /// <summary>
        /// Public route
        /// </summary>
        public string[] PublicRoute
        {
            get
            {
                return new string[]
                {
                    Constants.MODULE_AUTH_SIGNIN_PATH,
                    Constants.MODULE_ERROR_ERROR_PATH,
                };
            }
        }
    }
}
