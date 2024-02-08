// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Areas.Users.Controllers
{
    [Area(Constants.MODULE_USER_AREA)]
    public class UserListController : BaseController
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
