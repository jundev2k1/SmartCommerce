// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Common;

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
