

namespace ErpManager.ERP.Areas.Users.Controllers
{
	[Area(Constants.MODULE_USER_AREA)]
	public class UserCommonController : UserBaseController
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public UserCommonController(
			IServiceFacade serviceFacade,
			ILocalizer localizer,
			SessionManager sessionManager,
			ValueTextManager valueTextManager,
			IFileLogger logger) : base(serviceFacade, sessionManager, localizer, logger, valueTextManager)
		{
		}

		[HttpGet]
		[AllowAnonymous]
		[Route(Constants.ENDPOINT_COMMON_USER_GET_USER_LIST)]
		public IActionResult GetUsers(string searchKey = "")
		{
			var userSearch = new UserSearchDto
			{
				BranchId = this.OperatorBranchId,
				Keywords = searchKey
			};
			var result = _serviceFacade.Users.Search(userSearch, pageIndex: 1, pageSize: 6).Items;
			return Json(result);
		}
	}
}
