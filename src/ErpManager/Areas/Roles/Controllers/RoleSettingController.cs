// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Manager.Areas.Roles.ViewModels;

namespace ErpManager.Manager.Areas.Roles.Controllers
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
		public IActionResult Index(int id)
		{
			var roleInfo = _serviceFacade.Roles.Get(this.OperatorBranchId, id);
			if (roleInfo == null)
			{
				var errorMessage = _localizer.Messages["ErrorMessage_DataNotFound"].Value;
				return RedirectToErrorPage(errorMessage, ErrorCodeEnum.DataNotFound);
			}

			var data = new RoleSettingViewModel()
			{
				Information = roleInfo,
				PermissionGroups = GetPermissionGroupCollection(),
				InputOption = GetInitDropdownListItems(roleInfo),
			};
			return View(data);
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("/role/setting/update-information", Name = "RoleUpdateInfo")]
		public string UpdateRoleInfo(RoleSettingInfoRequestViewModel input)
		{
			return "";
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("/role/setting/update-settings", Name = "RoleUpdateSettings")]
		public string UpdateRoleSettings(RoleModel input)
		{
			return string.Empty;
		}
	}
}
