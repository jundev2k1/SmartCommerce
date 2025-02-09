// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Infrastructure.Middleware
{
	internal sealed class ResetConstantHandlerMiddleware : HandlerMiddlewareBase
	{
		/// <summary>DI</summary>
		private readonly RequestDelegate _next;

		/// <summary>
		/// Constructor
		/// </summary>
		public ResetConstantHandlerMiddleware(
			RequestDelegate next,
			IFileLogger logger,
			IHostingEnvironment environment) : base(next, logger, environment)
		{
			_next = next;
		}

		/// <summary>
		/// Invoke
		/// </summary>
		/// <param name="context">Context</param>
		protected override async Task Invoke(HttpContext context)
		{
			ResetConstants(context);
			await Task.CompletedTask;
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
