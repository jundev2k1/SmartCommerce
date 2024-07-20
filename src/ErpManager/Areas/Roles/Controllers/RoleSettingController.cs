// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.ERP.Areas.Roles.ViewModels;

namespace ErpManager.ERP.Areas.Roles.Controllers
{
	[Area(Constants.MODULE_ROLE_AREA)]
	public sealed class RoleSettingController : RoleBaseController
	{
		public RoleSettingController(
			IServiceFacade serviceFacade,
			IValidatorFacade validatorFacade,
			ILocalizer localizer,
			SessionManager sessionManager,
			ValueTextManager valueTextManager,
			IFileLogger logger) : base(serviceFacade, sessionManager, localizer, logger, valueTextManager)
		{
		}

		[HttpGet]
		[AllowAnonymous]
		[Route(Constants.MODULE_ROLE_ROLESETTING_PATH, Name = Constants.MODULE_ROLE_ROLESETTING_NAME)]
		public IActionResult Index(int? roleId)
		{
			var roleInfo = roleId.HasValue
				? _serviceFacade.Roles.Get(this.OperatorBranchId, roleId.Value)
				: new RoleModel();

			var data = new RoleSettingViewModel { PermissionGroups = GetPermissionGroupCollection() };
			return View(data);
		}
		[HttpPost]
		[AllowAnonymous]
		[Route(Constants.MODULE_ROLE_ROLESETTING_PATH, Name = Constants.MODULE_ROLE_ROLESETTING_NAME)]
		public IActionResult Index(RoleSettingViewModel viewModel)
		{
			return View(viewModel);
		}
	}
}
