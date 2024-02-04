using Common.Constants;

namespace ErpManager.Web.Middleware
{
    public class SessionCheckMiddleware : HandlerMiddlewareBase
    {
        private readonly RequestDelegate _next;

        public SessionCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Session.TryGetValue(Constants.SESSION_KEY_OPERATOR_ID, out _)
                && this.PublicRoute.Contains(context.Request.Path.Value) == false)
            {
                context.Response.Redirect(Constants.MODULE_AUTH_SIGNIN_PATH);
                return;
            }

            await _next(context);
        }
    }
}
