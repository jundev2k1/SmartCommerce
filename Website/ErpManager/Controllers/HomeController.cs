using Domain.Entities;
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
        [Route("/", Name = "Home")]
        public IActionResult Index()
        {
            var b = _Context.Brands.FirstOrDefault();
            return View();
        }
    }
}