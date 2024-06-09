// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Infrastructure.Common.Middleware;

namespace ErpManager.ERP.Common.Middleware
{
    public class ResetConstantHandlerMiddleware : HandlerMiddlewareBase
    {
        /// <summary>DI</summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// Constructor
        /// </summary>
        public ResetConstantHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context">Context</param>
        public async Task Invoke(HttpContext context)
        {
            ResetConstants(context);
            await _next(context);
        }

        private void ResetConstants(HttpContext context)
        {
            Constants.PAGE_LANGUAGE_OPTIONS = GetCurrentCulture(context);
        }

        private string GetCurrentCulture(HttpContext context)
        {
            var result = context.Features
                .Get<IRequestCultureFeature>()
                .RequestCulture.UICulture.Name;
            return result;
        }
    }
}
