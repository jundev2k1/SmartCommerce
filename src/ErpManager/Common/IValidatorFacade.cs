// Copyright (c) 2024 - Jun Dev. All rights reserved

using FluentValidation.Results;

namespace ErpManager.ERP.Common
{
	public interface IValidatorFacade
	{
		public ValidationResult UserValidate(UserModel model);

		public ValidationResult ProductValidate(ProductModel model);
	}
}
