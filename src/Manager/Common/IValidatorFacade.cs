// Copyright (c) 2024 - Jun Dev. All rights reserved

using FluentValidation.Internal;
using FluentValidation.Results;

namespace SmartCommerce.Manager.Common
{
	public interface IValidatorFacade
	{
		public Task<ValidationResult> UserValidate(UserModel model, Action<ValidationStrategy<UserModel>>? option = null);

		public Task<ValidationResult> RoleValidate(RoleModel model, Action<ValidationStrategy<RoleModel>>? option = null);

		public Task<ValidationResult> ProductValidate(ProductModel model, Action<ValidationStrategy<ProductModel>>? option = null);
	}
}
