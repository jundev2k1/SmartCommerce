// Copyright (c) 2024 - Jun Dev. All rights reserved

using SmartCommerce.Domain.Extensions.FilterModels;

namespace SmartCommerce.Manager.Areas.Roles.ViewModels
{
    public sealed class RoleListViewModel
	{
		public SearchResultModel<RoleModel> PageData { get; set; } = new SearchResultModel<RoleModel>();

		public RoleFilterModel SearchFields { get; set; } = new RoleFilterModel();

		public RoleInputOptionViewModel InputOption { get; set; } = new RoleInputOptionViewModel();

		public int PageIndex { get; set; } = 1;

		public int PageSize { get; set; } = Constants.DEFAULT_PAGE_SIZE;
	}
}
