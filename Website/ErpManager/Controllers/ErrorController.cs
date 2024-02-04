using Common.Constants;
using Microsoft.AspNetCore.Mvc;

namespace ErpManager.Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route(Constants.MODULE_HOME_ERROR_PATH, Name = Constants.MODULE_HOME_ERROR_NAME)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
