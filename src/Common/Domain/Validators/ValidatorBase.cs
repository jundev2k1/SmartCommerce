// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Validator
{
    public class ValidatorBase<T> : AbstractValidator<T>
    {
        protected bool CheckMail()
        {
            return true;
        }
    }
}
