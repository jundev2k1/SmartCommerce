// Copyright (c) 2024 - Jun Dev. All rights reserved

using SmartCommerce.Domain.Extensions.FilterModels;

namespace SmartCommerce.Manager.Areas.Users.ViewModels
{
    public sealed class UserListViewModel
	{
		public SearchResultModel<UserModel> PageData { get; set; } = new SearchResultModel<UserModel>();

		public UserFilterModel SearchFields { get; set; } = new UserFilterModel();

		public UserInputOptionViewModel InputOption { get; set; } = new UserInputOptionViewModel();
	}
}
