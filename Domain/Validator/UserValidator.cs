using Domain.Entities;
using FluentValidation;

namespace Domain.Validator
{
    public sealed class UserValidator : ValidatorBase<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.BranchID)
                .NotNull().WithMessage("")
                .NotEmpty().WithMessage("");

            RuleFor(user => user.UserId)
                .NotNull().WithMessage("")
                .NotEmpty().WithMessage("");

            RuleFor(user => user.UserName)
                .NotNull().WithMessage("")
                .NotEmpty().WithMessage("Is required")
                .MinimumLength(6).WithMessage("")
                .MaximumLength(18).WithMessage("");

            RuleFor(user => user.Password)
                .NotNull().WithMessage("")
                .NotEmpty().WithMessage("Is required")
                .MinimumLength(6).WithMessage("")
                .MaximumLength(18).WithMessage("");

            RuleFor(user => user.Sex)
                .NotNull().WithMessage("")
                .IsInEnum().WithMessage("");

            RuleFor(user => user.Status)
                .NotNull().WithMessage("")
                .IsInEnum().WithMessage("");

            RuleFor(user => user.Email)
                .NotNull().WithMessage("")
                .NotEmpty().WithMessage("Is required")
                .EmailAddress().WithMessage("");

            RuleFor(user => user.PhoneNumber)
                .NotNull().WithMessage("")
                .NotEmpty().WithMessage("Is required")
                .MaximumLength(20).WithMessage("")
                .Matches("^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$").WithMessage("");
        }
    }
}
