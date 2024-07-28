// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Manager.Areas.Users.ViewModels
{
	public sealed class UserInputOptionViewModel
	{
		public List<SelectListItem> Status { get; set; } = new List<SelectListItem>();

		public List<SelectListItem> Sex { get; set; } = new List<SelectListItem>();

		public List<SelectListItem> DeleteFlg { get; set; } = new List<SelectListItem>();
	}
}
