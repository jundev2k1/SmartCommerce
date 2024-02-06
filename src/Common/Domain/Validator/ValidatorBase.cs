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
