// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewComponents
{
	public sealed class CreatedByBadgeViewComponent : ViewComponentBase
	{
		public CreatedByBadgeViewComponent(
			ILocalizer localizer,
			IServiceFacade serviceFacade,
			ValueTextManager valueTextManager,
			SessionManager sessionManager)
			: base(localizer, serviceFacade, valueTextManager, sessionManager)
		{
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
