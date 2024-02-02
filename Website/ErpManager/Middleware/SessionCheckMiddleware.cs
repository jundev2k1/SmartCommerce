using Common.Constants;

namespace ErpManager.Web.Middleware
{
    public class SessionCheckMiddleware
    {
        /// <summary>Request delegate</summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="next"></param>
        public SessionCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context">Context</param>
        public async Task Invoke(HttpContext context)
        {
            if (!context.Session.TryGetValue(Constants.SESSION_KEY_OPERATOR_ID, out _)
                && context.Request.Path.Value != "/login")
            {
                context.Response.Redirect("/login");
                return;
            }

            await _next(context);
        }
    }

}
