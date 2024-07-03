// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.ERP.Areas.Products.ViewModels;

namespace ErpManager.ERP.Areas.Users.Controllers
{
	[Area(Constants.MODULE_USER_AREA)]
	public sealed class UserListController : UserBaseController
	{
		public UserListController(
			IServiceFacade serviceFacade,
			IValidatorFacade validatorFacade,
			ILocalizer localizer,
			SessionManager sessionManager,
			ValueTextManager valueTextManager,
			IFileLogger logger) : base(serviceFacade, sessionManager, localizer, logger, valueTextManager)
		{
		}

		[HttpGet]
		[Authorization(Permission.CanReadListUser)]
		[Route(Constants.MODULE_USER_USERLIST_PATH, Name = Constants.MODULE_USER_USERLIST_NAME)]
		public IActionResult Index(int page = 1)
		{
			ViewData[Constants.VIEWDATA_KEY_PAGE_INDEX] = page;

			var condition = new UserSearchDto
			{
				BranchId = this.OperatorBranchId,
			};
			var data = _serviceFacade.Users.Search(condition, page, Constants.DEFAULT_PAGE_SIZE);

			return View(new UserListViewModel { PageData = data, PageIndex = page });
		}
	}
}
