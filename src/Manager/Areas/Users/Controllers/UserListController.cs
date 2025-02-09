// Copyright (c) 2024 - Jun Dev. All rights reserved

using SmartCommerce.Manager.Areas.Users.ViewModels;

namespace SmartCommerce.Manager.Areas.Users.Controllers
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
			var condition = new UserFilterModel { BranchId = this.OperatorBranchId };
			var userList = _serviceFacade.Users.GetByCriteria(condition, page, Constants.DEFAULT_PAGE_SIZE);
			var data = new UserListViewModel
			{
				PageIndex = page,
				PageData = userList,
				InputOption = GetInitDropdownListItems(new UserModel())
			};
			return View(data);
		}
		[HttpPost]
		[Authorization(Permission.CanReadListUser)]
		[Route(Constants.MODULE_USER_USERLIST_PATH, Name = Constants.MODULE_USER_USERLIST_NAME)]
		public IActionResult Index(UserListViewModel viewModel)
		{
			var searchParams = viewModel.SearchFields;
			searchParams.BranchId = this.OperatorBranchId;

			// Set initial value for dropdown list
			viewModel.InputOption = GetInitDropdownListItems(viewModel.SearchFields.MapSearchToModel());

			// Check page index out of range data collection
			if (viewModel.PageData.TotalPage < viewModel.PageIndex)
				viewModel.PageIndex = 1;

			viewModel.PageData = _serviceFacade.Users.GetByCriteria(
				searchParams,
				viewModel.PageIndex,
				viewModel.PageSize);
			return View(viewModel);
		}
	}
}
