// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Areas.Users.Controllers
{
    [Area(Constants.MODULE_USER_AREA)]
    public class UserDetailController : BaseController
    {
        [HttpGet]
        [PermissionAttribute(Permission.CanReadListUser)]
        [Route($"{Constants.MODULE_USER_USERDETAIL_PATH}/{{id}}", Name = Constants.MODULE_USER_USERDETAIL_NAME)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
