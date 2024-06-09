// Copyright (c) 2024 - Jun Dev. All rights reserved

using FluentValidation.Results;

namespace ErpManager.ERP.Common.Validators
{
    public sealed class ValidatorFacade : IValidatorFacade
    {
        private IServiceProvider _serviceProvider;
        public ValidatorFacade(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ValidationResult UserValidate(UserModel model) => _serviceProvider.GetRequiredService<IValidator<UserModel>>().Validate(model);

        public ValidationResult ProductValidate(ProductModel model) => _serviceProvider.GetRequiredService<IValidator<ProductModel>>().Validate(model);
    }
}
