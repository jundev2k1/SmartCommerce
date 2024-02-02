using Domain.Entities;
using Domain.Enum;
using ErpManager.Web;
using Microsoft.AspNetCore.Mvc;

namespace ErpManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBContext _Context;

        /// <summary>
        /// Constructor
        /// </summary>
        public HomeController(DBContext context)
        {
            _Context = context;
        }

        /// <summary>
        /// Dashboard page
        /// </summary>
        /// <returns></returns>
        [PermissionAttribute(Permission.CanReadUser)]
        [Route("/", Name = "Home")]
        public IActionResult Index()
        {
            return View();
        }
    }
}