using Common.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ErpManager.Web.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// On action executing
        /// </summary>
        /// <param name="context">Context</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Initialize();
            base.OnActionExecuting(context);
        }

        /// <summary>
        /// Initialize
        /// </summary>
        private void Initialize()
        {
            SetOperatorInitialize();
            SetDefaultViewValue();
        }

        /// <summary>
        /// Set operator initialize
        /// </summary>
        private void SetOperatorInitialize()
        {

        }

        /// <summary>
        /// Set default view value
        /// </summary>
        private void SetDefaultViewValue()
        {
            var url = Request.Path;
            ViewData[Constants.GLOBAL_KEY_TITLE] = "1234";
        }

        /// <summary>Operator id</summary>
        public string OperatorId { get; private set; } = string.Empty;
        /// <summary>Operator id</summary>
        public string OperatorName { get; private set; } = string.Empty;
        /// <summary>Operator id</summary>
        public string OperatorPermission { get; private set; } = string.Empty;
    }
}
