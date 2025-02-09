// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.Areas.Products.ViewModels
{
	public sealed class ProductInputOptionViewModel
	{
		public List<SelectListItem> TakeOverId { get; set; } = new List<SelectListItem>();
	
		public List<SelectListItem> Status { get; set; } = new List<SelectListItem>();

		public List<SelectListItem> DisplayPrice { get; set; } = new List<SelectListItem>();

		public List<SelectListItem> DeleteFlg { get; set; } = new List<SelectListItem>();
	}
}
