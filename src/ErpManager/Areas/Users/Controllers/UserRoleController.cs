// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Areas.Users.Controllers
{
    [Area(Constants.MODULE_USER_AREA)]
    public sealed class UserRoleController : BaseController
    {
        private readonly IServiceFacade _serviceFacade;
        private readonly SessionManager _sessionManager;
        public UserRoleController(IServiceFacade serviceFacade, SessionManager sessionManager)
            : base(serviceFacade, sessionManager)
        {
            _serviceFacade = serviceFacade;
            _sessionManager = sessionManager;
        }

        [HttpGet]
        [PermissionAttribute(Permission.CanReadDetailRole)]
        [Route(Constants.MODULE_USER_USERROLE_PATH, Name = Constants.MODULE_USER_USERROLE_NAME)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
