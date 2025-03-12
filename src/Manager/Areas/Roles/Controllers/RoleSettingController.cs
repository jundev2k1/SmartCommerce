// Copyright (c) 2024 - Jun Dev. All rights reserved

using SmartCommerce.Manager.Areas.Roles.ViewModels;

namespace SmartCommerce.Manager.Areas.Roles.Controllers
{
	[Area(Constants.MODULE_ROLE_AREA)]
	public sealed class RoleSettingController : RoleBaseController
	{
		private readonly IValidatorFacade _validatorFacade;

		public RoleSettingController(
			IServiceFacade serviceFacade,
			IValidatorFacade validatorFacade,
			ILocalizer localizer,
			SessionManager sessionManager,
			ValueTextManager valueTextManager,
			IFileLogger logger) : base(serviceFacade, sessionManager, localizer, logger, valueTextManager)
		{
			_validatorFacade = validatorFacade;
		}

		[HttpGet]
		[Authorization(Permission.CanReadDetailRole)]
		[Route(Constants.MODULE_ROLE_ROLESETTING_PATH, Name = Constants.MODULE_ROLE_ROLESETTING_NAME)]
		public async Task<IActionResult> Index(int? id)
		{
			var roleInfo = id.HasValue
				? await _serviceFacade.Roles.Get(this.OperatorBranchId, id.Value)
				: new RoleModel();
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
		public async Task<IActionResult> UpdateRoleInfo([FromBody]RoleSettingInfoRequestViewModel data)
		{
			var validate = await _validatorFacade.RoleValidate(
				ConvertToRoleModel(data),
				option => option.IncludeRuleSets("Create"));
			if (validate.Errors.Any())
			{
				var response = new ResponseResultModel<string, string>()
				{
					IsSuccess = false,
					Message = string.Empty
				};
				return Json(response);
			}
			return Json(string.Empty);
		}

		/// <summary>
		/// Convert role info to role model (ignore permission info)
		/// </summary>
		/// <param name="input">Role info input</param>
		/// <returns>Role model</returns>
		private RoleModel ConvertToRoleModel(RoleSettingInfoRequestViewModel input)
		{
			var result = new RoleModel()
			{
				BranchId = this.OperatorBranchId,
				RoleId = input.RoleId,
				Name = input.Name,
				Priority = input.Priority,
				Description = input.Description,
			};
			return result;
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("/role/setting/update-permission", Name = "RoleUpdatePermission")]
		public IActionResult UpdateRolePermission(RoleModel input)
		{
			return Json(string.Empty);
		}
	}
}
