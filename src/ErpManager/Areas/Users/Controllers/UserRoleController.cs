// Copyright (c) 2024 - Jun Dev. All rights reserved

using Common.Constants;
using Domain.Enum;
using ErpManager.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ErpManager.Web.Areas.Users.Controllers
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
