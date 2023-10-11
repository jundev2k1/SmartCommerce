using Microsoft.AspNetCore.Mvc;

namespace ErpManager.Web.Areas.Users.Controllers
{
    [Area("users")]
    public class UserController : Controller
    {
        [Route("/user/user-list", Name ="UserList")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
