// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Domain.Dtos.SearchDtos;

namespace ErpManager.ERP.Areas.Users.Controllers
{
    [Area(Constants.MODULE_USER_AREA)]
    public class UserListController : BaseController
    {
        private IServiceFacade _serviceFacade;
        public UserListController(IServiceFacade serviceFacade)
        {
            _serviceFacade = serviceFacade;
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
