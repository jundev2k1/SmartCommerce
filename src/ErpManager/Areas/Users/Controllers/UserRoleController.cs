// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Areas.Users.Controllers
{
    [Area(Constants.MODULE_USER_AREA)]
    public class UserRoleController : BaseController
    {
        [HttpGet]
        [PermissionAttribute(Permission.CanAccessUserRole)]
        [Route(Constants.MODULE_USER_USERROLE_PATH, Name = Constants.MODULE_USER_USERROLE_NAME)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
