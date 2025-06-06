﻿// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Common
{
	public interface IServiceFacade
	{
		IBranchService Branches { get; }

		IRoleService Roles { get; }

		IUserService Users { get; }

		IProductCategoryService ProductCategories { get; }

		IProductService Products { get; }

		ITokenService Tokens { get; }

		IMemberService Members { get; }

		IMailTemplateService MailTemplates { get; }

		INotificationService Notifications { get; }
	}
}
