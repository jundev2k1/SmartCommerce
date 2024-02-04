using Common.Constants;
using Domain.Entities;
using Domain.Enum;
using ErpManager.Web;
using ErpManager.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ErpManager.Controllers
{
    public class HomeController : BaseController
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
        [PermissionAttribute(Permission.CanAccessDashBoard)]
        [Route("/", Name = Constants.MODULE_HOME_DASHBOARD_NAME)]
        [Route(Constants.MODULE_HOME_DASHBOARD_PATH)]
        public IActionResult Index()
        {
            return View();
        }
    }
}