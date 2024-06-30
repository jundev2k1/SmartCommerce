// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Infrastructure.Middleware
{
	internal sealed class CompressionMiddleware : HandlerMiddlewareBase
	{
		private readonly RequestDelegate _next;

		public CompressionMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			await _next(context);
		}
	}
}
