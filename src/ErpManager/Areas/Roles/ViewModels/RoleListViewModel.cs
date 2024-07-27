// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Areas.Roles.ViewModels
{
	public sealed class RoleListViewModel
	{
		public SearchResultModel<RoleModel> PageData { get; set; } = new SearchResultModel<RoleModel>();

		public RoleSearchDto SearchFields { get; set; } = new RoleSearchDto();

		public RoleInputOptionViewModel InputOption { get; set; } = new RoleInputOptionViewModel();

		public int PageIndex { get; set; } = 1;

		public int PageSize { get; set; } = Constants.DEFAULT_PAGE_SIZE;
	}
}
