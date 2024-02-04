using Common.Constants;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;

namespace ErpManager.Web.Areas.Users.Controllers
{
    [Area(Constants.MODULE_USER_AREA)]
    public class UserListController : Controller
    {
        [HttpGet]
        [PermissionAttribute(Permission.CanReadListUser)]
        [Route(Constants.MODULE_USER_USERLIST_PATH, Name = Constants.MODULE_USER_USERLIST_NAME)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
