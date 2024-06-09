// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Areas.Users.Controllers
{
    [Area(Constants.MODULE_USER_AREA)]
    public sealed class UserListController : BaseController
    {
        private readonly IServiceFacade _serviceFacade;
        private readonly SessionManager _sessionManager;
        public UserListController(IServiceFacade serviceFacade, SessionManager sessionManager)
            : base(serviceFacade, sessionManager)
        {
            _serviceFacade = serviceFacade;
            _sessionManager = sessionManager;
        }

        [HttpGet]
        [PermissionAttribute(Permission.CanReadListUser)]
        [Route(Constants.MODULE_USER_USERLIST_PATH, Name = Constants.MODULE_USER_USERLIST_NAME)]
        public IActionResult Index(int page = 1)
        {
            ViewData[Constants.VIEWDATA_KEY_PAGE_INDEX] = page;

            var condition = new UserSearchDto
            {
                BranchId = this.OperatorBranchId,
            };
            var data = _serviceFacade.Users.Search(condition, page, Constants.DEFAULT_PAGE_SIZE);

            return View(data);
        }
    }
}
