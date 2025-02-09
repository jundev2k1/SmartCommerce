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
		public IActionResult Index(int page = 1)
		{
			var condition = new RoleFilterModel { BranchId = OperatorBranchId };
			var data = _serviceFacade.Roles.GetByCriteria(condition, page, Constants.DEFAULT_PAGE_SIZE);

			return View(new RoleListViewModel { PageData = data, PageIndex = page });
		}
		[HttpPost]
		[Authorization(Permission.CanReadListRole)]
		[Route(Constants.MODULE_ROLE_ROLELIST_PATH, Name = Constants.MODULE_ROLE_ROLELIST_NAME)]
		public IActionResult Index(RoleListViewModel viewModel)
		{
			var searchParams = viewModel.SearchFields;
			searchParams.BranchId = OperatorBranchId;

			// Check page index out of range data collection
			if (viewModel.PageData.TotalPage < viewModel.PageIndex)
				viewModel.PageIndex = 1;

			viewModel.PageData = _serviceFacade.Roles.GetByCriteria(
				searchParams,
				viewModel.PageIndex,
				viewModel.PageSize);
			return View(viewModel);
		}
	}
}
