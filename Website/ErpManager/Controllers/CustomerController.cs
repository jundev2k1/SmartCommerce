using Microsoft.AspNetCore.Mvc;

namespace ErpManager.Web.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
