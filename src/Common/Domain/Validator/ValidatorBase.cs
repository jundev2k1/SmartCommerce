// Copyright (c) 2024 - Jun Dev. All rights reserved

using FluentValidation;

namespace Domain.Validator
{
    public class ValidatorBase<T> : AbstractValidator<T>
    {
        protected bool CheckMail()
        {
            return true;
        }
    }
}
