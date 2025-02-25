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
		public async Task<IActionResult> Index()
		{
			var condition = GetFiltersByRequest();
			var userList = await _serviceFacade.Users.GetByCriteria(condition);
			var data = new UserListViewModel
			{
				PageData = userList,
				InputOption = GetInitDropdownListItems(new UserModel())
			};
			return View(data);
		}

		/// <summary>
		/// Get filters by request
		/// </summary>
		/// <returns>User filters</returns>
		private UserFilterModel GetFiltersByRequest()
		{
			var parameter = new UserFilterModel()
			{
				Keywords = GetRequestParam<string>(Constants.REQUEST_KEY_KEYWORD, string.Empty),
				BranchId = this.OperatorBranchId,
				UserId = GetRequestParam<string>(Constants.REQUEST_KEY_USER_USER_ID, string.Empty),
				UserName = GetRequestParam<string>(Constants.REQUEST_KEY_USER_USERNAME, string.Empty),
				FirstName = GetRequestParam<string>(Constants.REQUEST_KEY_USER_FIRSTNAME, string.Empty),
				LastName = GetRequestParam<string>(Constants.REQUEST_KEY_USER_LASTNAME, string.Empty),
				Email = GetRequestParam<string>(Constants.REQUEST_KEY_USER_EMAIL, string.Empty),
				Status = GetRequestParam<UserStatusEnum>(Constants.REQUEST_KEY_USER_STATUS, UserStatusEnum.Active),
				Address1 = GetRequestParam<string>(Constants.REQUEST_KEY_USER_ADDRESS1, string.Empty),
				Address2 = GetRequestParam<string>(Constants.REQUEST_KEY_USER_ADDRESS2, string.Empty),
				Address3 = GetRequestParam<string>(Constants.REQUEST_KEY_USER_ADDRESS3, string.Empty),
				Address4 = GetRequestParam<string>(Constants.REQUEST_KEY_USER_ADDRESS4, string.Empty),
				PageNumber = GetRequestParam<int>(Constants.REQUEST_KEY_PAGE_NO, 1),
				PageSize = GetRequestParam<int>(Constants.REQUEST_KEY_PAGE_SIZE, Constants.DEFAULT_PAGE_SIZE),
				OrderBy = GetRequestParam<string>(Constants.REQUEST_KEY_SORT_BY, string.Empty),
				OrderByDirection = GetRequestParam<string>(Constants.REQUEST_KEY_SORT_DIRECTION, string.Empty),
			};

			// Reset value if limit is exceeded
			if (parameter.PageSize <= 0) parameter.PageSize = Constants.DEFAULT_PAGE_SIZE;
			if (parameter.PageNumber <= 0) parameter.PageNumber = 1;

			return parameter;
		}
	}
}
