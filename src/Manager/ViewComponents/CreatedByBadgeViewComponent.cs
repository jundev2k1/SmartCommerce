// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewComponents
{
	public sealed class CreatedByBadgeViewComponent : ViewComponent
	{
		private readonly ILocalizer _localizer;
		private readonly IServiceFacade _serviceFacade;
		public CreatedByBadgeViewComponent(ILocalizer localizer, IServiceFacade serviceFacade)
		{
			_localizer = localizer;
			_serviceFacade = serviceFacade;
		}

		public IViewComponentResult Invoke(
			string branchId,
			string createdBy,
			DateTime dateCreated,
			string className = "",
			bool isPill = false)
		{
			var createdByName = (createdBy == Constants.DEFAULT_FLG_CREATED_BY_SYSTEM)
				? Constants.DEFAULT_FLG_CREATED_BY_SYSTEM
				: _serviceFacade.Users.Get(branchId, createdBy)?.FullName;
			var data = new CreatedByBadgeViewModel
			{
				CreatedName = createdByName,
				DateCreated = dateCreated,
				ClassName = className,
				IsPill = isPill
			};
			return View(data);
		}
	}
}
