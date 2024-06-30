// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Common.Validators
{
	public sealed class UserValidator : ValidatorBase<UserModel>
	{
		public UserValidator(ILocalizer localizer, IServiceFacade serviceFacade) : base(serviceFacade)
		{
			RuleFor(user => user.BranchId)
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
				.Matches(Constants.REGEX_VALID_PHONE_NUMBER).WithMessage("");
		}
	}
}
