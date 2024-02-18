// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Common
{
    public interface IValidatorFacade
    {
        public ValidationResult UserValidate(UserModel model);

        public ValidationResult ProductValidate(ProductModel model);
    }
}
