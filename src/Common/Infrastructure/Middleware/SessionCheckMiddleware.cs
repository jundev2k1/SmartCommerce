// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Infrastructure.Middleware
{
	internal sealed class SessionCheckMiddleware : HandlerMiddlewareBase
	{
		private readonly RequestDelegate _next;

		public SessionCheckMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			var isNeedLogin = IsValidRoute(context.Request.Path.Value) == false
				&& context.Session.TryGetValue(Constants.SESSION_KEY_OPERATOR_ID, out _) == false;
			if (isNeedLogin)
			{
				context.Response.Redirect(Constants.MODULE_AUTH_SIGNIN_PATH);
				return;
			}

			await _next(context);
		}
	}
}
