﻿// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewComponents
{
	public sealed class NavBarViewComponent : ViewComponentBase
	{
		public NavBarViewComponent(
			ILocalizer localizer,
			IServiceFacade serviceFacade,
			ValueTextManager valueTextManager,
			SessionManager sessionManager)
			: base(localizer, serviceFacade, valueTextManager, sessionManager)
		{
		}

		public IViewComponentResult Invoke(string currentMenu)
		{
			var sidebarJson = File.ReadAllText($"{Environment.CurrentDirectory}{Constants.SCM_FILE_PATH_SIDEBAR_SETTING}");
			var menu = JsonConvert.DeserializeObject<List<MenuViewModel>>(sidebarJson);

			ViewBag.OperatorPermisson = GetOperatorPermisson();
			return View(menu);
		}

		/// <summary>
		/// Get operator permisson
		/// </summary>
		/// <returns>Permission list</returns>
		private string[] GetOperatorPermisson()
		{
			var result = HttpContext.Session.GetString(Constants.SESSION_KEY_OPERATOR_PERMISSION).ToStringOrEmpty();
			return result.Split(",");
		}
	}
}
