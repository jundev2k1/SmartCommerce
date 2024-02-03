using Common.Constants;
using Domain.Entities;
using Domain.Enum;
using ErpManager.Web;
using Microsoft.AspNetCore.Mvc;

namespace ErpManager.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public HomeController()
        {
        }

        /// <summary>
        /// Dashboard page
        /// </summary>
        /// <returns></returns>
        [PermissionAttribute(Permission.CanReadUser)]
        [Route("/", Name = Constants.MODULE_HOME_DASHBOARD_NAME)]
        [Route(Constants.MODULE_HOME_DASHBOARD_PATH)]
        public IActionResult Index()
        {
            return View();
        }
    }
}