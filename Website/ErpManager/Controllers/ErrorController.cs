using Microsoft.AspNetCore.Mvc;

namespace ErpManager.Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("error-page", Name = "ErrorPage")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
