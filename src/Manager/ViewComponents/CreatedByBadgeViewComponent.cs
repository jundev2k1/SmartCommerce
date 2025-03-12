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

		public async Task<IViewComponentResult> InvokeAsync(
			string branchId,
			string createdBy,
			DateTime dateCreated,
			string className = "",
			bool isPill = false)
		{
			if (createdBy != Constants.DEFAULT_FLG_CREATED_BY_SYSTEM)
			{
				var user = await _serviceFacade.Users.Get(branchId, createdBy);
				createdBy = user?.UserName ?? Constants.DEFAULT_FLG_CREATED_BY_SYSTEM;
			}
			var data = new CreatedByBadgeViewModel
			{
				CreatedName = createdBy,
				DateCreated = dateCreated,
				ClassName = className,
				IsPill = isPill
			};
			return View(data);
		}
	}
}
