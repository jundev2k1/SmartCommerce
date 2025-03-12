// Copyright (c) 2024 - Jun Dev. All rights reserved

using SmartCommerce.Manager.Areas.Roles.ViewModels;

namespace SmartCommerce.Manager.Areas.Roles.Controllers
{
	[Area(Constants.MODULE_ROLE_AREA)]
	public sealed class RoleListController : RoleBaseController
	{
		public RoleListController(
			IServiceFacade serviceFacade,
			IValidatorFacade validatorFacade,
			ILocalizer localizer,
			SessionManager sessionManager,
			ValueTextManager valueTextManager,
			IFileLogger logger) : base(serviceFacade, sessionManager, localizer, logger, valueTextManager)
		{
		}

		[HttpGet]
		[Authorization(Permission.CanReadListRole)]
		[Route(Constants.MODULE_ROLE_ROLELIST_PATH, Name = Constants.MODULE_ROLE_ROLELIST_NAME)]
		public async Task<IActionResult> Index()
		{
			var condition = GetFiltersByRequest();
			var roleList = await _serviceFacade.Roles.GetByCriteria(condition);
			var data = new RoleListViewModel
			{
				PageData = roleList,
			};
			return View(data);
		}

		/// <summary>
		/// Get filters by request
		/// </summary>
		/// <returns>Role filters</returns>
		private RoleFilterModel GetFiltersByRequest()
		{
			var parameter = new RoleFilterModel()
			{
				Keywords = GetRequestParam<string>(Constants.REQUEST_KEY_KEYWORD, string.Empty),
				BranchId = this.OperatorBranchId,
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
