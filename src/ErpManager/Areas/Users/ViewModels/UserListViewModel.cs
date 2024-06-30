// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Areas.Products.ViewModels
{
	public class UserListViewModel
	{
		public SearchResultModel<UserModel> PageData { get; set; } = new SearchResultModel<UserModel>();

		public UserSearchDto SearchFields { get; set; } = new UserSearchDto();

		public int PageIndex { get; set; } = 1;

		public int PageSize { get; set; } = Constants.DEFAULT_PAGE_SIZE;
	}
}
