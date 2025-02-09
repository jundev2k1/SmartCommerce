// Copyright (c) 2024 - Jun Dev. All rights reserved

using FluentValidation.Internal;
using FluentValidation.Results;

namespace SmartCommerce.Manager.Common.Validators
{
	public sealed class ValidatorFacade : IValidatorFacade
	{
		private IServiceProvider _serviceProvider;
		public ValidatorFacade(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public async Task<ValidationResult> UserValidate(UserModel model, Action<ValidationStrategy<UserModel>>? option = null)
			=> await ExecuteValidate<UserModel>(model, option);

		public async Task<ValidationResult> RoleValidate(RoleModel model, Action<ValidationStrategy<RoleModel>>? option = null)
			=> await ExecuteValidate(model, option);

		public async Task<ValidationResult> ProductValidate(ProductModel model, Action<ValidationStrategy<ProductModel>>? option = null)
			=> await ExecuteValidate<ProductModel>(model, option);
	
		private async Task<ValidationResult> ExecuteValidate<T>(T model, Action<ValidationStrategy<T>>? option = null)
		{
			var provider = _serviceProvider.GetRequiredService<IValidator<T>>();
			var result = option == null
				? await provider.ValidateAsync(model)
				: await provider.ValidateAsync(model, option);
			return result;
		}
	}
}
