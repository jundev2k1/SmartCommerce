// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Areas.Users.Controllers
{
	[Area(Constants.MODULE_USER_AREA)]
	public sealed class UserRoleController : UserBaseController
	{
		public UserRoleController(
			IServiceFacade serviceFacade,
			IValidatorFacade validatorFacade,
			ILocalizer localizer,
			SessionManager sessionManager,
			ValueTextManager valueTextManager,
			IFileLogger logger) : base(serviceFacade, sessionManager, localizer, logger, valueTextManager)
		{
		}

		[HttpGet]
		[Authorization(Permission.CanReadDetailRole)]
		[Route(Constants.MODULE_USER_USERROLE_PATH, Name = Constants.MODULE_USER_USERROLE_NAME)]
		public IActionResult Index()
		{
			return View();
		}
	}
}
