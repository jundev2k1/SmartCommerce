// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Infrastructure.Middleware
{
	internal sealed class CompressionMiddleware : HandlerMiddlewareBase
	{
		private readonly RequestDelegate _next;

		public CompressionMiddleware(RequestDelegate next, IFileLogger logger, IHostingEnvironment environment)
			: base(next, logger, environment)
		{
			_next = next;
		}

		protected override async Task Invoke(HttpContext context)
		{
			await Task.CompletedTask;
		}
	}
}
