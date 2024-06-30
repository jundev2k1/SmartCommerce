// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Infrastructure.Middleware
{
	internal sealed class ExceptionHandlingMiddleware : HandlerMiddlewareBase
	{
		private readonly RequestDelegate _next;
		private readonly IFileLogger _logger;

		public ExceptionHandlingMiddleware(RequestDelegate next, IFileLogger logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Exception: {ex.Message}");
				context.Response.Redirect(Constants.MODULE_AUTH_SIGNIN_PATH);
			}
		}
	}
}
