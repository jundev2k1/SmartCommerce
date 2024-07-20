// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Infrastructure.Middleware
{
	public abstract class HandlerMiddlewareBase
	{
		private readonly RequestDelegate _next;
		protected readonly IFileLogger _logger;
		protected readonly IHostingEnvironment _environment;

		/// <summary>
		/// Constructor
		/// </summary>
		protected HandlerMiddlewareBase(
			RequestDelegate next,
			IFileLogger logger,
			IHostingEnvironment environment)
		{
			_next = next;
			_logger = logger;
			_environment = environment;
		}
		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await Invoke(context);
				await _next(context);
			}
			catch (Exception ex)
			{
				if (!_environment.IsDevelopment())
					_logger.LogError($"Exception: {ex.Message}");

				throw;
			}
		}

		protected abstract Task Invoke(HttpContext context);

		/// <summary>
		/// Set error message
		/// </summary>
		/// <param name="message">Message</param>
		protected void SetErrorMessage(HttpContext context, string message)
		{
			context.Session.SetString(Constants.SESSION_KEY_PAGE_ERROR_MESSAGE, message);
		}
	}
}
