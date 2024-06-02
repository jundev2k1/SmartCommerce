// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Common;
using System.Text.RegularExpressions;

namespace ErpManager.Infrastructure.Common.Middleware
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
        /// Is valid route
        /// </summary>
        /// <param name="currentRoutePath">Current route path</param>
        /// <returns>Is valid route</returns>
        public bool IsValidRoute(string currentRoutePath)
        {
            foreach (var route in this.PublicRoute)
            {
                var routePattern = $"^{route}$";
                var routeItemMatch = Regex.Match(route, Constants.REGEX_FOR_GET_ROUTE_ITEM);
                if (routeItemMatch.Success)
                {
                    var regexRouteItemPattern = @"[^/]+";
                    routePattern = routePattern.Replace(routeItemMatch.Value, regexRouteItemPattern);
                }

                if (Regex.IsMatch(currentRoutePath, routePattern)) return true;
            }

            return false;
        }

        /// <summary>Public route</summary>
        public string[] PublicRoute
        {
            get
            {
                return new string[]
                {
                    Constants.MODULE_AUTH_SIGNIN_PATH,
                    Constants.MODULE_ERROR_ERROR_PATH,
                    Constants.MODULE_PRODUCT_PRODUCTPREVIEW_PATH,
                    Constants.MODULE_COMMON_CHANGE_LANGUAGE_PATH,
                };
            }
        }
    }
}
