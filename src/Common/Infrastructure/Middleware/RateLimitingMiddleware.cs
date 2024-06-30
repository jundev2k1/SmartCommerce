// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Infrastructure.Middleware
{
	internal sealed class RateLimitingMiddleware : HandlerMiddlewareBase
	{
		private readonly RequestDelegate _next;
		private static readonly Dictionary<string, RateLimitInfo> UserAccess = new Dictionary<string, RateLimitInfo>();
		private readonly int _limitInSeconds = 1;
		private readonly int _maxRequests = 24;

		public RateLimitingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			var userIP = context.Connection.RemoteIpAddress.ToString();

			if (UserAccess.ContainsKey(userIP))
			{
				var rateLimitInfo = UserAccess[userIP];
				if ((DateTime.Now - rateLimitInfo.LastAccessTime).TotalSeconds < _limitInSeconds)
				{
					if (rateLimitInfo.RequestCount >= _maxRequests)
					{
						context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
						await context.Response.WriteAsync("Rate limit exceeded. Try again later.");
						return;
					}

					rateLimitInfo.RequestCount++;
				}
				else
				{
					rateLimitInfo.RequestCount = 1;
					rateLimitInfo.LastAccessTime = DateTime.Now;
				}
			}
			else
			{
				UserAccess[userIP] = new RateLimitInfo
				{
					RequestCount = 1,
					LastAccessTime = DateTime.Now
				};
			}

			await _next(context);
		}
	}
}
