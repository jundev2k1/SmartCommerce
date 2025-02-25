namespace SmartCommerce.Manager.Areas.Users.Controllers
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
		public async Task<IActionResult> GetUsers(string searchKey = "")
		{
			var userSearch = new UserFilterModel
			{
				BranchId = this.OperatorBranchId,
				Keywords = searchKey,
				PageNumber = 1,
				PageSize = 6,
			};
			var searchResult = await _serviceFacade.Users.GetByCriteria(userSearch);
			return Json(searchResult.Items);
		}
	}
}
