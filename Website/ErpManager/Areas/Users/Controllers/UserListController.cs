using Common.Constants;
using Microsoft.AspNetCore.Mvc;

namespace ErpManager.Web.Areas.Users.Controllers
{
    [Area(Constants.MODULE_USER_AREA)]
    public class UserListController : Controller
    {
        [Route(Constants.MODULE_USER_USERLIST_PATH, Name = Constants.MODULE_USER_USERLIST_NAME)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
